using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetVersionInfo();
        }
        private void SetVersionInfo()
        {
            //this.label1.Text = "1.0.0.1";
            //this.label1.Text = "1.0.0.2";
            this.label1.Text = "1.0.0.4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK："+ ClassBLL.GetStr());
        }
    }
}
