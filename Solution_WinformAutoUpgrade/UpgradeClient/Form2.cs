using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility;

namespace UpgradeClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AutoUpdater au = new AutoUpdater();
            try
            {
                //au.Update();
                //string FILENAME = "UpgradeClient.exe";
                //string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Environment.Exit(0);

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
    }
}
