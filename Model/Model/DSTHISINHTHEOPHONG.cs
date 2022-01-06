namespace Model.Model
{
    using global::Model.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSTHISINHTHEOPHONG")]
    public partial class DSTHISINHTHEOPHONG
    {
        [Key]
        [StringLength(4)]
        public string UNIQUEID { get; set; }

        [Required]
        [StringLength(12)]
        public string CMND { get; set; }

        [Required]
        [StringLength(4)]
        public string MAPHONG { get; set; }

        [Required]
        [StringLength(5)]
        public string SBD { get; set; }

        public double? DIEMNGHE { get; set; }

        public double? DIEMNOI { get; set; }

        public double? DIEMDOC { get; set; }

        public double? DIEMVIET { get; set; }

        public virtual PHONGTHI PHONGTHI { get; set; }

        public virtual THISINH THISINH { get; set; }

        public string SDT
        {
            get { return THISINH.SDT; }
        }

        public string HOTEN
        {
            get { return THISINH.HOTEN; }
        }

        public string TENPHONG
        {
            get { return PHONGTHI.TENPHONG; }
        }

        public List<DSTHISINHTHEOPHONG> GetAll()
        {
            return new DAL_DSThiSinhTheoPhong().GetAll();
        }

        public List<DSTHISINHTHEOPHONG> GetPhongThi(string MaPhong)
        {
            return new DAL_DSThiSinhTheoPhong().GetDSThiSinhTheoPhong(MaPhong);
        }

        public bool Insert(DSTHISINHTHEOPHONG DSThiSinhTheoPhongThi)
        {
            return new DAL_DSThiSinhTheoPhong().Insert(DSThiSinhTheoPhongThi);
        }

        public bool Update(DSTHISINHTHEOPHONG DSThiSinhTheoPhongThiMoi)
        {
            return new DAL_DSThiSinhTheoPhong().Update(DSThiSinhTheoPhongThiMoi);
        }

        public bool Delete(DSTHISINHTHEOPHONG DSThiSinhTheoPhongThi)
        {
            return new DAL_DSThiSinhTheoPhong().Delete(DSThiSinhTheoPhongThi);
        }
    }
}
