using DesktopApp.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DesktopApp
{
    public partial class FormChinh : Form
    {
        Form activeForm;

        public FormChinh()
        {
            InitializeComponent();
        }

        public void openCildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        public void QuanLyThiSinh_Click(object sender, EventArgs e)
        {
            openCildForm(new GUI_QuanLyThiSinh());
        }

        private void QuanLyKhoaThi_Click(object sender, EventArgs e)
        {
            openCildForm(new GUI_QuanLyKhoaThi());
        }

        private void TimKiemThongTinThiSinh_Click(object sender, EventArgs e)
        {
            openCildForm(new GUI_TimKiemThiSinh());
        }

        private void btnDangKyThi_Click(object sender, EventArgs e)
        {
            openCildForm(new GUI_DangKy());
        }
    }
}
