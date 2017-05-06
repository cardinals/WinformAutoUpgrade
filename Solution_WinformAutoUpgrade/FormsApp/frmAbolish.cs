
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class frmAbolish : Form
    {
        public DateTime startDate = new DateTime();

        public frmAbolish()
        {
            InitializeComponent();
        }

        private void frmAbolish_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            startDate = DateTime.Now;        
        }

        /// <summary>
        /// 废票登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
             
        }
      

        /// <summary>
        /// 转为大写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ticketCode.Text.Length >= 26)
            {
                this.ticketCode.Text = this.ticketCode.Text.ToUpper();
            }
            else if (this.ticketCode.Text == "请输入完整的门票票面号")
            {
                this.ticketCode.Text = "";
            }
        }

        private void ticketCode_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ticketCode.Text) && this.ticketCode.Text == "请输入完整的门票票面号")
            {
                this.ticketCode.Text = "";
            }
        }

        private void ticketCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ticketCode.Text))
            {
                this.ticketCode.Text = "请输入完整的门票票面号";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}