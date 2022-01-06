using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Model;

namespace DesktopApp.GUI
{
    public partial class GUI_TimKiemThiSinh : Form
    {
        public GUI_TimKiemThiSinh()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string HoTen = txtTimKiemHoTen.Text;
            string SDT = txtTimKiemSDT.Text;
            if(HoTen.Equals("") || SDT.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để tìm kiếm");
                return;
            }

            int tmp = 0;
            DSTHISINHTHEOPHONG DS = new DSTHISINHTHEOPHONG();
            List<DSTHISINHTHEOPHONG> ListDS = new List<DSTHISINHTHEOPHONG>();
            ListDS = DS.GetAll();
            foreach(DSTHISINHTHEOPHONG DanhSach in ListDS)
            {
                if(DanhSach.HOTEN.Trim().Equals(HoTen) && DanhSach.SDT.Equals(SDT))
                {
                    DS = DanhSach;
                    tmp = 1;
                }
            }
            if(tmp == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả");
                txtHoTen.Text = "";
                txtSBD.Text = "";
                txtSDT.Text = "";
                txtPhongThi.Text = "";
                txtDiemNghe.Text = "";
                txtDiemNoi.Text = "";
                txtDiemDoc.Text = "";
                txtDiemViet.Text = "";
                return;
            }
            txtHoTen.Text = DS.HOTEN;
            txtSBD.Text = DS.SBD;
            txtSDT.Text = DS.SDT;
            txtPhongThi.Text = DS.TENPHONG;
            txtDiemNghe.Text = DS.DIEMNGHE.ToString();
            txtDiemNoi.Text = DS.DIEMNOI.ToString();
            txtDiemDoc.Text = DS.DIEMDOC.ToString();
            txtDiemViet.Text = DS.DIEMVIET.ToString();
        }
    }
}
