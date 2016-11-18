using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Utility;
using System.IO;
namespace UpgradeClient
{
    public partial class Form1 : Form
    {
        static string fileName = "help.txt";
        string defaultHelpInfo = "\r\n无帮助内容";
        public Form1()
        {
            InitializeComponent();
            this.timer1.Enabled = true;
            // this.label2.Text = "1.0.0.2";
            this.lblHelpInfo.Text = defaultHelpInfo;
        }
        
        private void btnUpadate_Click(object sender, EventArgs e)
        {
            //new Form2().ShowDialog();
            this.Upgrade();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Upgrade()
        {
            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (System.Net.WebException exp)
            {
                MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Xml.XmlException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException exp)
            {
                MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetHelpPanelText()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string fileValue = sr.ReadToEnd();
                    if (!string.IsNullOrEmpty(fileValue))
                    {
                        this.lblHelpInfo.Text = "\r\n" + fileValue;
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblHelpInfo.Text = defaultHelpInfo;
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetHelpPanelText();
        }
    }
}
