namespace Model.Model
{
    using global::Model.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANGKY")]
    public partial class DANGKY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string CMND { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MAKHOA { get; set; }

        [Required]
        [StringLength(2)]
        public string TRINHDO { get; set; }

        public virtual THISINH THISINH { get; set; }

        public virtual KHOATHI KHOATHI { get; set; }

        public string HOTEN
        {
            get { return THISINH.HOTEN; }
        }

        public string SDT
        {
            get { return THISINH.SDT; }
        }

        public string TENKHOA
        {
            get { return KHOATHI.TENKHOA; }
        }

        public List<DANGKY> GetAll()
        {
            return new DAL_DangKy().GetAll();
        }

        public bool Insert(DANGKY DangKy)
        {
            return new DAL_DangKy().InsertDK(DangKy);
        }

        public bool Update(DANGKY DangKyMoi)
        {
            return new DAL_DangKy().Update(DangKyMoi);
        }

        public bool Delete(DANGKY DangKy)
        {
            return new DAL_DangKy().Delete(DangKy);
        }
    }
}
