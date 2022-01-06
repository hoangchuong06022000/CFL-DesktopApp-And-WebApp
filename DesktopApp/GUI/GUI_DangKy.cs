using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class GUI_DangKy : Form
    {
        List<DANGKY> ListDangKy;
        List<THISINH> ListThiSinh;
        List<KHOATHI> ListKhoaThi;
        KHOATHI KhoaThiHienTai;

        public GUI_DangKy()
        {
            InitializeComponent();
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadData()
        {
            KhoaThiHienTai = new KHOATHI();
            THISINH TS = new THISINH();
            DANGKY DK = new DANGKY();
            ListDangKy = DK.GetAll();
            ListThiSinh = TS.GetAll();
            ListKhoaThi = KhoaThiHienTai.GetAll();
            KhoaThiHienTai = ListKhoaThi[ListKhoaThi.Count - 1];
            txtKhoaThi.Text = KhoaThiHienTai.TENKHOA;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ListDangKy.ToList();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 200;
            column.DataPropertyName = "HOTEN";
            column.Name = "Họ Tên";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 130;
            column.DataPropertyName = "SDT";
            column.Name = "SĐT";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 140;
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 200;
            column.DataPropertyName = "TENKHOA";
            column.Name = "Tên Khóa Thi";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 130;
            column.DataPropertyName = "TRINHDO";
            column.Name = "Trình Độ";
            dataGridView1.Columns.Add(column);

            comboTenThiSinh.Items.Clear();
            foreach(THISINH ThiSinh in ListThiSinh)
            {
                comboTenThiSinh.Items.Add(ThiSinh.HOTEN);
            }

            comboTrinhDo.Items.Add("A2");
            comboTrinhDo.Items.Add("B1");
            comboTrinhDo.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboTenThiSinh.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtKhoaThi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboTrinhDo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void comboTenThiSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (THISINH TS in ListThiSinh)
            {
                if (comboTenThiSinh.SelectedItem.ToString().Trim().Equals(TS.HOTEN.Trim()))
                {
                    txtCMND.Text = TS.CMND;
                }
            }
        }

        public bool checkInput()
        {
            string HoTen = comboTenThiSinh.Text;
            string CMND = txtCMND.Text;
            string KhoaThi = txtKhoaThi.Text;
            string TrinhDo = comboTrinhDo.Text;

            if (HoTen.Equals("") || CMND.Equals("") || KhoaThi.Equals("") || TrinhDo.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return false;
            }

            int Trung = 0;
            foreach (THISINH TS in ListThiSinh)
            {
                if (TS.HOTEN.Trim().Equals(HoTen.Trim()))
                {
                    Trung = 1;
                    break;
                }
            }

            if(Trung == 0)
            {
                MessageBox.Show("Thí sinh này chưa có thông tin", "Thông báo");
                return false;
            }

            if(TrinhDo.Equals("A2") == false && TrinhDo.Equals("B1") == false)
            {
                MessageBox.Show("Vui lòng chọn trình độ A2 hoặc B1", "Thông báo");
                return false;
            }


            return true;
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            GUI_QuanLyThiSinh frameAddTour = new GUI_QuanLyThiSinh();
            frameAddTour.ShowDialog();
            comboTenThiSinh.Items.Clear();
            foreach (THISINH ThiSinh in ListThiSinh)
            {
                comboTenThiSinh.Items.Add(ThiSinh.HOTEN);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                DANGKY DK = new DANGKY();

                string CMND = txtCMND.Text;
                string TrinhDo = comboTrinhDo.Text;

                DK.CMND = CMND;
                DK.MAKHOA = KhoaThiHienTai.MAKHOA;
                DK.TRINHDO = TrinhDo;
                if (DK.Insert(DK) == false)
                {
                    MessageBox.Show("Thí sinh này đã đăng ký", "Thông báo");
                    return;
                }

                ListDangKy = DK.GetAll();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListDangKy;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int VT = 0;
            try
            {
                VT = dataGridView1.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                string message = "Bạn chưa chọn thông tin để sửa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }

            if (MessageBox.Show("Bạn có muốn sửa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (checkInput() == true)
                {
                    DANGKY DK = new DANGKY();

                    string CMND = txtCMND.Text;
                    string TrinhDo = comboTrinhDo.Text;

                    DK.CMND = CMND;
                    DK.MAKHOA = KhoaThiHienTai.MAKHOA;
                    DK.TRINHDO = TrinhDo;

                    if (DK.Update(DK) == false)
                    {
                        MessageBox.Show("Không được phép sửa", "Thông báo");
                        return;
                    }

                    ListDangKy = DK.GetAll();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ListDangKy;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int VT = 0;
            try
            {
                VT = dataGridView1.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                string message = "Bạn chưa chọn thông tin để xóa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DANGKY DK = new DANGKY();
                DK.CMND = dataGridView1.Rows[VT].Cells[2].Value.ToString();
                if (DK.Delete(DK) == false)
                {
                    MessageBox.Show("Bạn không được phép xóa", "Thông báo");
                    return;
                }

                ListDangKy = DK.GetAll();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListDangKy;
            }
        }
    }
}
