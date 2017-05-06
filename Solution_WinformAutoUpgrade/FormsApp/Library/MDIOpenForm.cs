using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp.Library
{
    public class MDIOpenForm
    {
        public static void Show(Form mdiForm, Form chlidForm)
        {
            bool isShow = false;
            Form[] formList = mdiForm.MdiChildren;
            foreach (Form frm in formList)
            {
                if (frm.Name == chlidForm.Name)
                {
                    frm.BringToFront();
                    isShow = true;
                }
                else
                {
                    frm.Close();
                }
            }

            if (!isShow)
            {
                chlidForm.MdiParent = mdiForm;
                chlidForm.WindowState = FormWindowState.Maximized;
                chlidForm.FormBorderStyle = FormBorderStyle.None;
                chlidForm.Dock = DockStyle.Fill;
                chlidForm.Show();
            }
        }
    }
}
