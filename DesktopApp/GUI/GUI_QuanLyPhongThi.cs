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
    public partial class GUI_QuanLyPhongThi : Form
    {
        public KHOATHI KhoaThiHienTai;
        List<PHONGTHI> ListPhongThi;
        List<PHONGTHI> ListAllPhongThi;
        int SapXep = 1;

        public GUI_QuanLyPhongThi()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void formPhongThi(KHOATHI KhoaThi)
        {
            KhoaThiHienTai = KhoaThi;

            DateTime NgayHienTai = DateTime.Now;
            if (KhoaThiHienTai.NGAYTHI.CompareTo(NgayHienTai) < 0)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                SapXep = 0;
            }

            comboTrinhDo.Items.Add("A2");
            comboTrinhDo.Items.Add("B1");
            comboTrinhDo.SelectedIndex = 0;

            PHONGTHI Phong = new PHONGTHI();
            ListPhongThi = Phong.GetPhongThi(KhoaThiHienTai.MAKHOA);
            ListAllPhongThi = Phong.GetAll();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ListPhongThi.ToList();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 100;
            column.DataPropertyName = "MAPHONG";
            column.Name = "Mã Phòng";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 200;
            column.DataPropertyName = "TENPHONG";
            column.Name = "Tên Phòng";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 200;
            column.DataPropertyName = "TRINHDO";
            column.Name = "Trình Độ";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 150;
            column.DataPropertyName = "CATHI";
            column.Name = "Ca Thi";
            dataGridView1.Columns.Add(column);

            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.Width = 150;
            columnButton.HeaderText = "";
            columnButton.Text = "Danh sách thí sinh";
            columnButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(columnButton);
        }

        public string MaTuDong()
        {
            string Ma = "";
            if (ListAllPhongThi.Count != 0)
            {
                int So = 0;
                string MaPhong = ListAllPhongThi[ListAllPhongThi.Count - 1].MAPHONG;
                Ma = MaPhong.Substring(0, 1);
                string STT = MaPhong.Substring(1, MaPhong.Length - 1);
                So = int.Parse(STT);
                So++;
                if (So < 10)
                    Ma += "00" + So;
                else
                    if (So < 99)
                    Ma += "0" + So;
                else
                    Ma += So;
            }
            else
                Ma = "P001"; 
            return Ma;
        }

        public string getSTT(string TrinhDo)
        {
            int dem = 1;
            string STT = "";
            foreach(PHONGTHI Phong in ListPhongThi)
            {
                if (Phong.TRINHDO.Trim().Equals(TrinhDo.Trim()))
                    dem++;
            }
            if (dem < 10)
                STT = "0" + dem;
            else
                STT = "" + dem;
            return STT;
        }

        public bool checkInput()
        {
            string TrinhDo = comboTrinhDo.Text;
            string CaThi = txtCaThi.Text;

            if (TrinhDo.Equals("A2") == false && TrinhDo.Equals("B1") == false)
            {
                MessageBox.Show("Vui lòng chọn đúng trình độ A1 hoặc B1", "Thông báo");
                return false;
            }

            if(CaThi.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập ca thi", "Thông báo");
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(checkInput())
            {
                string MaPhong = MaTuDong();
                string MaKhoa = KhoaThiHienTai.MAKHOA;
                string TrinhDo = comboTrinhDo.Text;
                string CaThi = txtCaThi.Text;
                string TenPhong = TrinhDo.Trim() + "P" + getSTT(TrinhDo);

                PHONGTHI PhongThi = new PHONGTHI();
                PhongThi.MAKHOA = MaKhoa;
                PhongThi.MAPHONG = MaPhong;
                PhongThi.TRINHDO = TrinhDo;
                PhongThi.CATHI = CaThi;
                PhongThi.TENPHONG = TenPhong;

                if(PhongThi.Insert(PhongThi) == false)
                {
                    MessageBox.Show("Không được phép thêm");
                    return;
                }

                ListPhongThi.Add(PhongThi);
                ListAllPhongThi.Add(PhongThi);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListPhongThi;
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
                string message = "Bạn chưa chọn Phòng Thi để sửa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }

            if (MessageBox.Show("Bạn có muốn sửa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (checkInput() == true)
                {
                    string CaThi = txtCaThi.Text;

                    PHONGTHI PhongThi = new PHONGTHI();
                    PhongThi.MAPHONG = dataGridView1.Rows[VT].Cells[0].Value.ToString();
                    PhongThi.CATHI = CaThi;

                    if (PhongThi.Update(PhongThi) == false)
                    {
                        MessageBox.Show("Không được phép sửa", "Thông báo");
                        return;
                    }

                    ListPhongThi = PhongThi.GetPhongThi(KhoaThiHienTai.MAKHOA);
                    ListAllPhongThi = PhongThi.GetAll();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ListPhongThi;
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
                string message = "Bạn chưa chọn Phòng Thi để xóa";
                string title = "Thông báo lỗi";
                MessageBox.Show(message, title);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string MaPhong = dataGridView1.Rows[VT].Cells[0].Value.ToString();
                PHONGTHI Phong = new PHONGTHI();

                foreach (PHONGTHI PhongThi in ListPhongThi)
                {
                    if (PhongThi.MAPHONG.Trim().Equals(MaPhong.Trim()))
                    {
                        Phong = PhongThi;
                        break;
                    }
                }

                if (Phong.Delete(Phong) == false)
                {
                    MessageBox.Show("Bạn không được phép xóa", "Thông báo");
                    return;
                }

                ListPhongThi.Remove(Phong);
                ListAllPhongThi.Remove(Phong);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ListPhongThi;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int VT = e.RowIndex;
            string MaPhong = dataGridView1.Rows[VT].Cells[0].Value.ToString();
            PHONGTHI Phong = new PHONGTHI();
            foreach (PHONGTHI PhongThi in ListPhongThi)
            {
                if (PhongThi.MAPHONG.Trim().Equals(MaPhong.Trim()))
                {
                    Phong = PhongThi;
                    break;
                }
            }

            if (e.ColumnIndex == 4)
            {
                DanhSachThiSinhTheoPhong frame = new DanhSachThiSinhTheoPhong();
                frame.formDanhSachThiSinh(Phong, SapXep);
                frame.ShowDialog();
                return;
            }

            comboTrinhDo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCaThi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
