using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Utility
{
    public partial class DownloadProgress : Form
    {
        private bool isFinished = false;
        private List<DownloadFileInfo> downloadFileList = null;
        private ManualResetEvent evtDownload = null;
        private ManualResetEvent evtPerDonwload = null;
        private WebClient clientDownload = null;

        public DownloadProgress(List<DownloadFileInfo> downloadFileList)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.downloadFileList = downloadFileList;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFinished && DialogResult.No == MessageBox.Show("当前正在更新，是否取消？", "自动升级", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (clientDownload != null)
                    clientDownload.CancelAsync();

                evtDownload.Set();
                evtPerDonwload.Set();
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            evtDownload = new ManualResetEvent(true);
            evtDownload.Reset();
            Thread t = new Thread(new ThreadStart(ProcDownload));
            t.Name = "download";
            t.Start();
        }

        long total = 0;
        long nDownloadedTotal = 0;

        private void ProcDownload()
        {
            evtPerDonwload = new ManualResetEvent(false);

            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                total += file.Size;
            }

            while (!evtDownload.WaitOne(0, false))
            {
                if (this.downloadFileList.Count == 0)
                    break;

                DownloadFileInfo file = this.downloadFileList[0];

                LogHelper.Debug(String.Format("Start Download:{0}", file.FileName));
                //Debug.WriteLine(String.Format("Start Download:{0}", file.FileName));

                this.ShowCurrentDownloadFileName(file.FileName);

                //下载
                clientDownload = new WebClient();

                clientDownload.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
                clientDownload.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadFileCompleted);

                evtPerDonwload.Reset();
                try
                {
                    /*
                     *  断目录存在不，不存的则添加
                     * **/
                    string path= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName);
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    }
                   clientDownload.DownloadFileAsync(new Uri(file.DownloadUrl), path + ".tmp", file);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(string.Format("DownloadFileFailed：DownloadUrl【{2}】,FileName【{0}】,error Msg【{1}】", file.FileFullName,ex.Message,file.DownloadUrl));
                }
               
                //等待下载完成
                evtPerDonwload.WaitOne();

                clientDownload.Dispose();
                clientDownload = null;

                //移除已下载的文件
                this.downloadFileList.Remove(file);
            }
            LogHelper.Debug("All Downloaded");
            //Debug.WriteLine("All Downloaded");

            if (this.downloadFileList.Count == 0)
                Exit(true);
            else
                Exit(false);

            evtDownload.Set();
        }

        void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadFileInfo file = e.UserState as DownloadFileInfo;
            nDownloadedTotal += file.Size;
            this.SetProcessBar(0, (int)(nDownloadedTotal * 100 / total));
            LogHelper.Debug(String.Format("Finish Download:{0}", file.FileName));
            //Debug.WriteLine(String.Format("Finish Download:{0}", file.FileName));
            //替换现有文件
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName);
            try
            {
                if (File.Exists(filePath))
                {
                    if (File.Exists(filePath + ".old"))
                        File.Delete(filePath + ".old");

                    File.Move(filePath, filePath + ".old");
                }
                File.Move(filePath + ".tmp", filePath);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("move file failed: filepath【{0}】;errror msg【{1}】",filePath,ex.Message));
            }
            //继续下载其它文件
            evtPerDonwload.Set();
        }

        void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.SetProcessBar(e.ProgressPercentage, (int)((nDownloadedTotal + e.BytesReceived) * 100 / total));
        }

        delegate void ShowCurrentDownloadFileNameCallBack(string name);
        private void ShowCurrentDownloadFileName(string name)
        {
            if (this.labelCurrentItem.InvokeRequired)
            {
                ShowCurrentDownloadFileNameCallBack cb = new ShowCurrentDownloadFileNameCallBack(ShowCurrentDownloadFileName);
                this.Invoke(cb, new object[] { name });
            }
            else
            {
                this.labelCurrentItem.Text = name;
            }
        }

        delegate void SetProcessBarCallBack(int current, int total);
        private void SetProcessBar(int current, int total)
        {
            if (this.progressBarCurrent.InvokeRequired)
            {
                SetProcessBarCallBack cb = new SetProcessBarCallBack(SetProcessBar);
                this.Invoke(cb, new object[] { current, total });
            }
            else
            {
                this.progressBarCurrent.Value = current;
                if (total > 100)
                    total = 100;
                this.progressBarTotal.Value = total;
            }
        }

        delegate void ExitCallBack(bool success);
        private void Exit(bool success)
        {
            if (this.InvokeRequired)
            {
                ExitCallBack cb = new ExitCallBack(Exit);
                this.Invoke(cb, new object[] { success });
            }
            else
            {
                this.isFinished = success;
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            evtDownload.Set();
            evtPerDonwload.Set();
        }
    }
}