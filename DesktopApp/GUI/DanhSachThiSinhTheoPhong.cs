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
    public partial class DanhSachThiSinhTheoPhong : Form
    {
        public PHONGTHI PhongThiHienTai;
        List<DSTHISINHTHEOPHONG> ListDSThiSinh;
        List<DSTHISINHTHEOPHONG> ListAllDSThiSinh;

        public DanhSachThiSinhTheoPhong()
        {
            InitializeComponent();
        }

        private void btnXepThiSinh_Click(object sender, EventArgs e)
        {
            int ToiDa = 5;
            List<DANGKY> ListDangKy;
            DANGKY DK = new DANGKY();
            ListDangKy = DK.GetAll();
            List<DANGKY> ListDangKyTheoTrinhDo = new List<DANGKY>();
            foreach (DANGKY DangKy in ListDangKy)
            {
                if (DangKy.TRINHDO.Trim().Equals(PhongThiHienTai.TRINHDO.Trim()))
                {
                    ListDangKyTheoTrinhDo.Add(DangKy);
                }
            }

            if(ListDangKyTheoTrinhDo.Count >= ToiDa && ListDangKyTheoTrinhDo.Count <= ToiDa + 5 )
            {
                int STT = 0;
                int SoLuong = ToiDa;
                if (ListDangKyTheoTrinhDo.Count % ToiDa >= 1 && ListDangKyTheoTrinhDo.Count % ToiDa <= 5)
                    SoLuong += ListDangKyTheoTrinhDo.Count % ToiDa;

                foreach(DANGKY DangKy in ListDangKyTheoTrinhDo)
                {
                    string STTSBD = "";
                    STT++;
                    if (STT < 10)
                        STTSBD += "00" + STT;
                    else
                        if (STT < 99)
                            STTSBD += "0" + STT;
                        else
                            STTSBD += STT;
                    SoLuong--;
                    DSTHISINHTHEOPHONG DS = new DSTHISINHTHEOPHONG();
                    DS.UNIQUEID = MaTuDong();
                    DS.CMND = DangKy.CMND;
                    DS.MAPHONG = PhongThiHienTai.MAPHONG;
                    DS.SBD = PhongThiHienTai.TRINHDO + STTSBD;
                    DS.DIEMNGHE = 0;
                    DS.DIEMNOI = 0;
                    DS.DIEMDOC = 0;
                    DS.DIEMVIET = 0;
                    if (DS.Insert(DS) == false)
                    {
                        MessageBox.Show("Không thể thêm vào","Thống báo");
                        return;
                    }
                    if (DangKy.Delete(DangKy) == false)
                    {
                        MessageBox.Show("Không thể xóa vào", "Thống báo");
                        return;
                    }
                    ListAllDSThiSinh.Add(DS);
                    if (SoLuong == 0)
                        break;
                }

                DSTHISINHTHEOPHONG DSThiSinh = new DSTHISINHTHEOPHONG();
                ListDSThiSinh = DSThiSinh.GetPhongThi(PhongThiHienTai.MAPHONG);
                dataGridView1.DataSource = ListDSThiSinh.ToList();
            }
            else
            {
                MessageBox.Show("Số lượng thí sinh không đủ", "Thông báo");
            }
        }

        private void btnLuuDiemThi_Click(object sender, EventArgs e)
        {
            string ID = "";
            double diemNghe = 0;
            double diemNoi = 0;
            double diemDoc = 0;
            double diemViet = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DSTHISINHTHEOPHONG DSTS = new DSTHISINHTHEOPHONG();
                ID = dataGridView1.Rows[i].Cells[0].Value.ToString();
                try
                {
                    diemNghe = double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    diemNoi = double.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    diemDoc = double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    diemViet = double.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                }
                catch(Exception)
                {
                    MessageBox.Show("Vui lòng nhập chính xác điểm", "Thông báo");
                    return;
                }
                if((diemNghe < 0 || diemNghe > 10)|| (diemNoi < 0 || diemNoi > 10) || (diemDoc < 0 || diemDoc > 10) || (diemViet < 0 || diemViet > 10))
                {
                    MessageBox.Show("Nhập sai điểm thi", "Thông báo");
                    return;
                }
                DSTS.UNIQUEID = ID;
                DSTS.DIEMNGHE = diemNghe;
                DSTS.DIEMNOI = diemNoi;
                DSTS.DIEMDOC = diemDoc;
                DSTS.DIEMVIET = diemViet;
                if (DSTS.Update(DSTS) == false)
                {
                    MessageBox.Show("Vui lòng nhập chính xác điểm", "Thông báo");
                    return;
                }
                
            }
            MessageBox.Show("Lưu điểm thành công", "Thông báo");
        }

        public string MaTuDong()
        {
            string Ma = "";
            int So = 0;
            string ID = ListAllDSThiSinh[ListAllDSThiSinh.Count - 1].UNIQUEID;
            Ma = ID.Substring(0, 1);
            string STT = ID.Substring(1, ID.Length - 1);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void formDanhSachThiSinh(PHONGTHI PhongThi, int SapXep)
        {
            PhongThiHienTai = PhongThi;

            DSTHISINHTHEOPHONG DS = new DSTHISINHTHEOPHONG();
            ListDSThiSinh = DS.GetPhongThi(PhongThiHienTai.MAPHONG);
            ListAllDSThiSinh = DS.GetAll();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ListDSThiSinh.ToList();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 60;
            column.DataPropertyName = "UNIQUEID";
            column.Name = "ID";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 150;
            column.DataPropertyName = "HOTEN";
            column.Name = "Họ Tên";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 90;
            column.DataPropertyName = "SDT";
            column.Name = "SDT";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 90;
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 80;
            column.DataPropertyName = "TENPHONG";
            column.Name = "Phòng Thi";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 100;
            column.DataPropertyName = "SBD";
            column.Name = "Số Báo Danh";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 50;
            column.DataPropertyName = "DIEMNGHE";
            column.Name = "Nghe";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 60;
            column.DataPropertyName = "DIEMNOI";
            column.Name = "Nói";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 60;
            column.DataPropertyName = "DIEMDOC";
            column.Name = "Đọc";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Width = 60;
            column.DataPropertyName = "DIEMVIET";
            column.Name = "Viết";
            dataGridView1.Columns.Add(column);

            if (ListDSThiSinh.Count != 0)
                btnXepThiSinh.Visible = false;
        }
    }
}
