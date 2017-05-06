

（一）快捷键
	   this.btndd.text="(&1)菜单ALT+1"


（二）子父窗体
1，父窗体设置isMdiContainer=true
2,子窗体MdiParent赋值：
				chlidForm.MdiParent = mdiForm;
                chlidForm.WindowState = FormWindowState.Maximized;
                chlidForm.FormBorderStyle = FormBorderStyle.None;
                chlidForm.Dock = DockStyle.Fill;
                chlidForm.Show();
3，隐藏子窗体的标题：load中设置this.ControlBox = false;  注：必须在load事件中   

private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }