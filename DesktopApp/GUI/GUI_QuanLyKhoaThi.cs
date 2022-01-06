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
    public partial class GUI_QuanLyKhoaThi : Form
    {

        List<KHOATHI> ListKhoaThi;

        public GUI_QuanLyKhoaThi()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            txtNgayThi.Value = DateTime.Now.AddDays(15).Date;
            KHOATHI KT = new KHOATHI();
            ListKhoaThi = KT.GetAll();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ListKhoaThi.ToList();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 150;
            column.DataPropertyName = "MAKHOA";
            column.Name = "Mã Khóa";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 300;
            column.DataPropertyName = "TENKHOA";
            column.Name = "Tên Khóa";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 200;
            column.DataPropertyName = "NGAYTHI";
            column.Name = "Ngày Thi";
            dataGridView1.Columns.Add(column);

            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.Width = 150;
            columnButton.HeaderText = "";
            columnButton.Text = "Danh sách phòng thi";
            columnButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(columnButton);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                string MaKhoaThi = MaTuDong();
                string TenKhoaThi = txtTenKhoaThi.Text;
                DateTime NgayThi = txtNgayThi.Value;

                KHOATHI KhoaThi = new KHOATHI();
                KhoaThi.MAKHOA = MaKhoaThi;
                KhoaThi.TENKHOA = TenKhoaThi;
                KhoaThi.NGAYTHI = NgayThi;

                if (KhoaThi.Insert(KhoaThi) == false)
                {
                    MessageBox.Show("Không được phép thêm", "Thông báo");
                    return;
                }

                ListKhoaThi.Add(KhoaThi);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListKhoaThi;
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
                string message = "Bạn chưa chọn Khóa Thi để sửa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }

            if (MessageBox.Show("Bạn có muốn sửa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (checkInput() == true)
                {
                    string MaKhoaThi = dataGridView1.Rows[VT].Cells[0].Value.ToString();
                    string TenKhoaThi = txtTenKhoaThi.Text;
                    DateTime NgayThi = txtNgayThi.Value;

                    KHOATHI KhoaThi = new KHOATHI();
                    KhoaThi.MAKHOA = MaKhoaThi;
                    KhoaThi.TENKHOA = TenKhoaThi;
                    KhoaThi.NGAYTHI = NgayThi;

                    if (KhoaThi.Update(KhoaThi) == false)
                    {
                        MessageBox.Show("Không được phép sửa", "Thông báo");
                        return;
                    }

                    ListKhoaThi = KhoaThi.GetAll();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ListKhoaThi;
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
                string message = "Bạn chưa chọn Khóa Thi để xóa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string MaKhoaThi = dataGridView1.Rows[VT].Cells[0].Value.ToString();
                KHOATHI KT = new KHOATHI();

                foreach (KHOATHI KhoaThi in ListKhoaThi)
                {
                    if (KhoaThi.MAKHOA.Trim().Equals(MaKhoaThi.Trim()))
                    {
                        KT = KhoaThi;
                        break;
                    }
                }

                if (KT.Delete(KT) == false)
                {
                    MessageBox.Show("Bạn không được phép xóa", "Thông báo");
                    return;
                }

                ListKhoaThi.Remove(KT);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListKhoaThi;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int VT = e.RowIndex;
            string MaKhoa = dataGridView1.Rows[VT].Cells[0].Value.ToString();
            KHOATHI KT = new KHOATHI();
            foreach (KHOATHI KhoaThi in ListKhoaThi)
            {
                if (KhoaThi.MAKHOA.Trim().Equals(MaKhoa.Trim()))
                {
                    KT = KhoaThi;
                    break;
                }
            }

            if (e.ColumnIndex == 3)
            {
                GUI_QuanLyPhongThi frame = new GUI_QuanLyPhongThi();
                frame.formPhongThi(KT);
                frame.ShowDialog();
                return;
            }

            txtTenKhoaThi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNgayThi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        public string MaTuDong()
        {
            string Ma = "";
            int So = 0;
            string MaKhoa = ListKhoaThi[ListKhoaThi.Count - 1].MAKHOA;
            Ma = MaKhoa.Substring(0, 1);
            string STT = MaKhoa.Substring(1, MaKhoa.Length - 1);
            So = int.Parse(STT);
            So++;
            if (So < 10)
                Ma += "00" + So;
            else
                if (So < 99)
                Ma += "0" + So;
            else
                Ma += So;
            return Ma;
        }

        public bool checkInput()
        {
            string TenKhoaThi = txtTenKhoaThi.Text;
            DateTime NgayHienTai = DateTime.Now;
            DateTime NgayThi = txtNgayThi.Value;
            TimeSpan t = NgayThi - NgayHienTai;
            double diff = t.TotalDays;

            if(TenKhoaThi.Equals("") || NgayThi == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return false;
            }

            if(diff < 14)
            {
                MessageBox.Show("Ngày thi phải sau ngày hiện tại 14 ngày", "Thông báo");
                return false;
            }

            return true;
        }
    }
}
