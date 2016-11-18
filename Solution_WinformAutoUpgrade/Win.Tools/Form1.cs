using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Win.Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = dialog.FileName;
                
            }
        }
        

        private void btnGetSize_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(this.textBox1.Text);
            double aa = fi.Length / 1024.0;
            this.listBox1.Items.Add(string.Format("文件名：{0} - {1} byte -{2}kb- ceiling({3}kb)",fi.Name,fi.Length, aa.ToString("f2"), Math.Ceiling(aa).ToString("f2")));
            
        }
    }
}
