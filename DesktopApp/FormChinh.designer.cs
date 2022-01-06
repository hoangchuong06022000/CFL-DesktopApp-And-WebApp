
namespace DesktopApp
{
    partial class FormChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimKiemThongTinThiSinh = new System.Windows.Forms.Button();
            this.QuanLyKhoaThi = new System.Windows.Forms.Button();
            this.QuanLyThiSinh = new System.Windows.Forms.Button();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnDangKyThi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.btnDangKyThi);
            this.panel1.Controls.Add(this.TimKiemThongTinThiSinh);
            this.panel1.Controls.Add(this.QuanLyKhoaThi);
            this.panel1.Controls.Add(this.QuanLyThiSinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 526);
            this.panel1.TabIndex = 0;
            // 
            // TimKiemThongTinThiSinh
            // 
            this.TimKiemThongTinThiSinh.FlatAppearance.BorderSize = 0;
            this.TimKiemThongTinThiSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimKiemThongTinThiSinh.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TimKiemThongTinThiSinh.ForeColor = System.Drawing.Color.White;
            this.TimKiemThongTinThiSinh.Location = new System.Drawing.Point(0, 253);
            this.TimKiemThongTinThiSinh.Name = "TimKiemThongTinThiSinh";
            this.TimKiemThongTinThiSinh.Size = new System.Drawing.Size(200, 42);
            this.TimKiemThongTinThiSinh.TabIndex = 10;
            this.TimKiemThongTinThiSinh.Text = "Tìm Kiếm Thông Tin Thí Sinh";
            this.TimKiemThongTinThiSinh.UseVisualStyleBackColor = true;
            this.TimKiemThongTinThiSinh.Click += new System.EventHandler(this.TimKiemThongTinThiSinh_Click);
            // 
            // QuanLyKhoaThi
            // 
            this.QuanLyKhoaThi.FlatAppearance.BorderSize = 0;
            this.QuanLyKhoaThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuanLyKhoaThi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.QuanLyKhoaThi.ForeColor = System.Drawing.Color.White;
            this.QuanLyKhoaThi.Location = new System.Drawing.Point(0, 205);
            this.QuanLyKhoaThi.Name = "QuanLyKhoaThi";
            this.QuanLyKhoaThi.Size = new System.Drawing.Size(200, 42);
            this.QuanLyKhoaThi.TabIndex = 8;
            this.QuanLyKhoaThi.Text = "Quản Lý Khóa Thi";
            this.QuanLyKhoaThi.UseVisualStyleBackColor = true;
            this.QuanLyKhoaThi.Click += new System.EventHandler(this.QuanLyKhoaThi_Click);
            // 
            // QuanLyThiSinh
            // 
            this.QuanLyThiSinh.FlatAppearance.BorderSize = 0;
            this.QuanLyThiSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuanLyThiSinh.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.QuanLyThiSinh.ForeColor = System.Drawing.Color.White;
            this.QuanLyThiSinh.Location = new System.Drawing.Point(0, 157);
            this.QuanLyThiSinh.Name = "QuanLyThiSinh";
            this.QuanLyThiSinh.Size = new System.Drawing.Size(200, 42);
            this.QuanLyThiSinh.TabIndex = 7;
            this.QuanLyThiSinh.Text = "Quản Lý Thí Sinh";
            this.QuanLyThiSinh.UseVisualStyleBackColor = true;
            this.QuanLyThiSinh.Click += new System.EventHandler(this.QuanLyThiSinh_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(866, 526);
            this.panelDesktop.TabIndex = 1;
            // 
            // btnDangKyThi
            // 
            this.btnDangKyThi.FlatAppearance.BorderSize = 0;
            this.btnDangKyThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKyThi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnDangKyThi.ForeColor = System.Drawing.Color.White;
            this.btnDangKyThi.Location = new System.Drawing.Point(3, 109);
            this.btnDangKyThi.Name = "btnDangKyThi";
            this.btnDangKyThi.Size = new System.Drawing.Size(197, 42);
            this.btnDangKyThi.TabIndex = 11;
            this.btnDangKyThi.Text = "Đăng Ký Thi";
            this.btnDangKyThi.UseVisualStyleBackColor = true;
            this.btnDangKyThi.Click += new System.EventHandler(this.btnDangKyThi_Click);
            // 
            // FormChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 526);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel1);
            this.Name = "FormChinh";
            this.Text = "Trung tâm ngoại ngữ";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button QuanLyKhoaThi;
        private System.Windows.Forms.Button QuanLyThiSinh;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button TimKiemThongTinThiSinh;
        private System.Windows.Forms.Button btnDangKyThi;
    }
}

