using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Win.Tools
{
    public partial class Form1 : Form
    {
        public const string XML_FILE_NAME = "updateService.xml";

        /// <summary>
        /// 选择的文件目录
        /// </summary>
        public string SelectedPath { get; set; }

        public UpdateFiles updateFiles { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.updateFiles = new UpdateFiles();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.txtVer1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtVer1.Text = this.txtVer4.Text = "1";
            this.txtVer2.Text = this.txtVer3.Text = "0";
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtVer1.Text) || string.IsNullOrEmpty(this.txtVer2.Text) || string.IsNullOrEmpty(this.txtVer3.Text) || string.IsNullOrEmpty(this.txtVer4.Text))
            {
                MessageBox.Show("请输入版本号");
                return;
            }
            if (string.IsNullOrEmpty(this.txtUrl.Text))
            {
                MessageBox.Show("请输入URL");
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件路径";
            fbd.SelectedPath = Environment.CurrentDirectory.ToString();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtFolderPath.Text = this.SelectedPath = fbd.SelectedPath;
                DisplayFiles(fbd.SelectedPath);
            }
        }

        private void DisplayFiles(string folder)
        {
            var di = new DirectoryInfo(folder);
            var files = di.GetFiles().ToList();
            this.listView1.Items.Clear();
            foreach (var file in files)
            {
                //显示
                ListViewItem item = new ListViewItem(new string[] { file.Name, Path.Combine(folder, file.Name), file.Length.ToString() });
                this.listView1.Items.Add(item);

                //
                this.updateFiles.Add(new File()
                {
                    path = file.Name,
                    url = this.txtUrl.Text + "/" + file.Name,
                    lastver = this.txtVer1.Text + "." + this.txtVer2.Text + "." + this.txtVer3.Text + "." + this.txtVer4.Text,
                    size = file.Length.ToString(),
                    needRestart = true
                });
            }
        }

        private void btnGenerateXmlFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = XML_FILE_NAME;
            sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            //sfd.InitialDirectory = @"c:\\";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = sfd.FileName;
                    Config.GenerateXmlFile(path, typeof(UpdateFiles), this.updateFiles);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("生成文件{0}失败，原因：{1}", XML_FILE_NAME, ex.Message));
                }
            }
        }
    }
}