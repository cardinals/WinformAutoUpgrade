namespace UpgradeClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnUpadate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlHelpInfo = new System.Windows.Forms.Panel();
            this.lblHelpInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlHelpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpadate
            // 
            this.btnUpadate.Location = new System.Drawing.Point(209, 110);
            this.btnUpadate.Name = "btnUpadate";
            this.btnUpadate.Size = new System.Drawing.Size(75, 35);
            this.btnUpadate.TabIndex = 0;
            this.btnUpadate.Text = "更 新";
            this.btnUpadate.UseVisualStyleBackColor = true;
            this.btnUpadate.Click += new System.EventHandler(this.btnUpadate_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "     ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.pnlHelpInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 271);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新内容";
            // 
            // pnlHelpInfo
            // 
            this.pnlHelpInfo.BackColor = System.Drawing.Color.White;
            this.pnlHelpInfo.Controls.Add(this.lblHelpInfo);
            this.pnlHelpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHelpInfo.Location = new System.Drawing.Point(3, 17);
            this.pnlHelpInfo.Name = "pnlHelpInfo";
            this.pnlHelpInfo.Size = new System.Drawing.Size(838, 251);
            this.pnlHelpInfo.TabIndex = 0;
            // 
            // lblHelpInfo
            // 
            this.lblHelpInfo.AutoSize = true;
            this.lblHelpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelpInfo.Location = new System.Drawing.Point(0, 0);
            this.lblHelpInfo.Name = "lblHelpInfo";
            this.lblHelpInfo.Size = new System.Drawing.Size(65, 12);
            this.lblHelpInfo.TabIndex = 0;
            this.lblHelpInfo.Text = "无帮助内容";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpadate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlHelpInfo.ResumeLayout(false);
            this.pnlHelpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpadate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlHelpInfo;
        private System.Windows.Forms.Label lblHelpInfo;
    }
}

