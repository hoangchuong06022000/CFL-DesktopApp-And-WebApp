
namespace DesktopApp.GUI
{
    partial class DanhSachThiSinhTheoPhong
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXepThiSinh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuuDiemThi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(844, 396);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnXepThiSinh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 50);
            this.panel1.TabIndex = 50;
            // 
            // btnXepThiSinh
            // 
            this.btnXepThiSinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(46)))));
            this.btnXepThiSinh.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnXepThiSinh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXepThiSinh.Location = new System.Drawing.Point(567, 3);
            this.btnXepThiSinh.Name = "btnXepThiSinh";
            this.btnXepThiSinh.Size = new System.Drawing.Size(231, 40);
            this.btnXepThiSinh.TabIndex = 52;
            this.btnXepThiSinh.Text = "XẾP PHÒNG THI";
            this.btnXepThiSinh.UseVisualStyleBackColor = false;
            this.btnXepThiSinh.Click += new System.EventHandler(this.btnXepThiSinh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "Danh Sách Thí Sinh";
            // 
            // btnLuuDiemThi
            // 
            this.btnLuuDiemThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(46)))));
            this.btnLuuDiemThi.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuuDiemThi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLuuDiemThi.Location = new System.Drawing.Point(311, 473);
            this.btnLuuDiemThi.Name = "btnLuuDiemThi";
            this.btnLuuDiemThi.Size = new System.Drawing.Size(231, 40);
            this.btnLuuDiemThi.TabIndex = 53;
            this.btnLuuDiemThi.Text = "LƯU";
            this.btnLuuDiemThi.UseVisualStyleBackColor = false;
            this.btnLuuDiemThi.Click += new System.EventHandler(this.btnLuuDiemThi_Click);
            // 
            // DanhSachThiSinhTheoPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 525);
            this.Controls.Add(this.btnLuuDiemThi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "DanhSachThiSinhTheoPhong";
            this.Text = "DanhSachThiSinhTheoPhong";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXepThiSinh;
        private System.Windows.Forms.Button btnLuuDiemThi;
    }
}