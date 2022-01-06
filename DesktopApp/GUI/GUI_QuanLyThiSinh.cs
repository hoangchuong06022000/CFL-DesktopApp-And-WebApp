using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Model;

namespace DesktopApp.GUI
{
    public partial class GUI_QuanLyThiSinh : Form
    {
        List<THISINH> ListThiSinh;

        public GUI_QuanLyThiSinh()
        {
            InitializeComponent();
            LoadData();
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
                string message = "Bạn chưa chọn Thí Sinh để xóa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string CMND = dataGridView1.Rows[VT].Cells[6].Value.ToString();
                THISINH TS = new THISINH();

                foreach (THISINH ThiSinh in ListThiSinh)
                {
                    if (ThiSinh.CMND.Trim().Equals(CMND.Trim()))
                    {
                        TS = ThiSinh;
                        break;
                    }
                }

                if (TS.Delete(TS) == false)
                {
                    MessageBox.Show("Bạn không được phép xóa", "Thông báo");
                    return;
                }

                ListThiSinh.Remove(TS);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListThiSinh;
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
                string message = "Bạn chưa chọn Thí Sinh để sửa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }

            if (MessageBox.Show("Bạn có muốn sửa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(checkInput() == true)
                {
                    THISINH TS = new THISINH();

                    DateTime NgayHienTai = DateTime.Now;
                    string HoTen = txtHoTen.Text;
                    DateTime NgaySinh = txtNgaySinh.Value;
                    string NoiSinh = txtNoiSinh.Text;
                    string GioiTinh = getGioiTinh();
                    string SDT = txtSDT.Text;
                    string Email = txtEmail.Text;
                    string CMND = txtCMND.Text;
                    DateTime NgayCap = txtNgayCap.Value;
                    string NoiCap = txtNoiCap.Text;

                    TS.HOTEN = HoTen;
                    TS.NGAYSINH = NgaySinh;
                    TS.NOISINH = NoiSinh;
                    TS.GIOITINH = GioiTinh;
                    TS.SDT = SDT;
                    TS.EMAIL = Email;
                    TS.CMND = CMND;
                    TS.NGAYCAP = NgayCap;
                    TS.NOICAP = NoiCap;
                    if (TS.Update(TS) == false)
                    {
                        MessageBox.Show("Không được phép sửa số CMND", "Thông báo");
                        return;
                    }

                    ListThiSinh = TS.GetAll();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ListThiSinh;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                THISINH TS = new THISINH();

                DateTime NgayHienTai = DateTime.Now;
                string HoTen = txtHoTen.Text;
                DateTime NgaySinh = txtNgaySinh.Value;
                string NoiSinh = txtNoiSinh.Text;
                string GioiTinh = getGioiTinh();
                string SDT = txtSDT.Text;
                string Email = txtEmail.Text;
                string CMND = txtCMND.Text;
                DateTime NgayCap = txtNgayCap.Value;
                string NoiCap = txtNoiCap.Text;

                TS.HOTEN = HoTen;
                TS.NGAYSINH = NgaySinh;
                TS.NOISINH = NoiSinh;
                TS.GIOITINH = GioiTinh;
                TS.SDT = SDT;
                TS.EMAIL = Email;
                TS.CMND = CMND;
                TS.NGAYCAP = NgayCap;
                TS.NOICAP = NoiCap;
                if (TS.Insert(TS) == false)
                {
                    MessageBox.Show("Thí sinh này đã tồn tại", "Thông báo");
                    return;
                }

                ListThiSinh.Add(TS);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListThiSinh;
            }
        }

        public void LoadData()
        {
            THISINH TS = new THISINH();
            ListThiSinh = TS.GetAll();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ListThiSinh.ToList();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 130;
            column.DataPropertyName = "HOTEN";
            column.Name = "Họ Tên";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 100;
            column.DataPropertyName = "NGAYSINH";
            column.Name = "Ngày Sinh";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 100;
            column.DataPropertyName = "NOISINH";
            column.Name = "Nơi Sinh";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 80;
            column.DataPropertyName = "GIOITINH";
            column.Name = "Giới Tính";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 70;
            column.DataPropertyName = "SDT";
            column.Name = "SĐT";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EMAIL";
            column.Name = "Email";
            column.Width = 100;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            column.Width = 90;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "NGAYCAP";
            column.Name = "Ngày Cấp";
            column.Width = 80;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "NOICAP";
            column.Name = "Nơi Cấp";
            column.Width = 100;
            dataGridView1.Columns.Add(column);
        }

        public bool checkInput()
        {
            DateTime NgayHienTai = DateTime.Now;
            string HoTen = txtHoTen.Text;
            DateTime NgaySinh = txtNgaySinh.Value;
            string NoiSinh = txtNoiSinh.Text;
            string GioiTinh = getGioiTinh();
            string SDT = txtSDT.Text;
            string Email = txtEmail.Text;
            string CMND = txtCMND.Text;
            DateTime NgayCap = txtNgayCap.Value;
            string NoiCap = txtNoiCap.Text;

            if(HoTen.Equals("") || NgaySinh == null || NoiSinh.Equals("") || GioiTinh.Equals("") || SDT.Equals("") || Email.Equals("") || CMND.Equals("") || NgayCap == null || NoiCap.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return false;
            }
            

            if (Regex.IsMatch(HoTen, "^[a-z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝàáâãèéêìíòóôõùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ A-Z]{1,50}$") == false)
            {
                MessageBox.Show("Họ Tên không hợp lệ", "Thông báo");
                return false;
            }

            if (Regex.IsMatch(CMND, "^[\\d{12}]|[\\d{9}]$") == false)
            {
                MessageBox.Show("Nhập sai số CMND", "Thông báo");
                return false;
            }

            if (Regex.IsMatch(SDT, "^(0\\d{9})$") == false)
            {
                MessageBox.Show("Nhập sai số điện thoại", "Thông báo");
                return false;
            }

            if (Regex.IsMatch(Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$") == false)
            {
                MessageBox.Show("Nhập sai Email", "Thông báo");
                return false;
            }

            TimeSpan diff = NgayHienTai - NgaySinh;
            long i = Math.Abs(diff.Ticks);
            DateTime newDate = new DateTime(i);
            if(newDate.Year <16)
            {
                MessageBox.Show("Bạn vẫn chưa đủ tuổi (phải đủ 16 tuổi)", "Thông báo");
                return false;
            }

            diff = NgaySinh - NgayCap;
            i = Math.Abs(diff.Ticks);
            newDate = new DateTime(i);
            if (newDate.Year < 15)
            {
                MessageBox.Show("Bạn nhập sai ngày cấp", "Thông báo");
                return false;
            }

            return true;
        }

        private string getGioiTinh()
        {
            if (rdNam.Checked == true)
                return "Nam";
            if (rdNu.Checked == true)
                return "Nữ";
            return "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNoiSinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtNgayCap.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtNoiCap.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("Nam"))
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CMND = txtTimKiemCMND.Text;
            string HoTen = txtTimKiemHoTen.Text;
            string SDT = txtTimKiemSDT.Text;

            List<THISINH> ListTimKiemKhachHang = new List<THISINH>();
            if (HoTen.Equals("") == false)
            {
                foreach (THISINH TS in ListThiSinh)
                {
                    if (TS.HOTEN.ToLower().Contains(HoTen.ToLower()))
                        ListTimKiemKhachHang.Add(TS);
                }
                if (ListTimKiemKhachHang.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả", "Thông báo");
                    return;
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListTimKiemKhachHang;
                return;
            }

            if (CMND.Equals("") == false)
            {
                foreach (THISINH TS in ListThiSinh)
                {
                    if (TS.CMND.ToLower().Equals(CMND.ToLower()))
                        ListTimKiemKhachHang.Add(TS);
                }
                if (ListTimKiemKhachHang.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả", "Thông báo");
                    return;
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListTimKiemKhachHang;
                return;
            }

            if (SDT.Equals("") == false)
            {
                foreach (THISINH TS in ListThiSinh)
                {
                    if (TS.SDT.ToLower().Equals(SDT.ToLower()))
                        ListTimKiemKhachHang.Add(TS);
                }
                if (ListTimKiemKhachHang.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả", "Thông báo");
                    return;
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListTimKiemKhachHang;
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListThiSinh;
        }
    }
}
