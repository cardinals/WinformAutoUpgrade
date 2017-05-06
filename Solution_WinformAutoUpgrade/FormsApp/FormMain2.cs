using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsApp.Library;

namespace FormsApp
{
    public partial class FormMain2 : Form
    {
        public FormMain2()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MDIOpenForm.Show(this, new Form1());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MDIOpenForm.Show(this, new frmAbolish());
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width, this.toolStrip1.Height - 2);
                e.Graphics.SetClip(rect);
            }
        }

        private void FormMain2_Load(object sender, EventArgs e)
        {
            this.tsBtnSale.Text = "(&1)售票\nALT+1";
            this.tsBtnOnline.Text = "(&2)电商及官网换票\nALT+2";
        }
    }
}
