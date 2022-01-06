namespace Model.Model
{
    using global::Model.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THISINH")]
    public partial class THISINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THISINH()
        {
            DANGKies = new HashSet<DANGKY>();
            DSTHISINHTHEOPHONGs = new HashSet<DSTHISINHTHEOPHONG>();
        }

        [Key]
        [StringLength(12)]
        public string CMND { get; set; }

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [Required]
        [StringLength(3)]
        public string GIOITINH { get; set; }

        [DataType(DataType.Date)]
        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(100)]
        public string NOISINH { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [DataType(DataType.Date)]
        public DateTime NGAYCAP { get; set; }

        [Required]
        [StringLength(100)]
        public string NOICAP { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKY> DANGKies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSTHISINHTHEOPHONG> DSTHISINHTHEOPHONGs { get; set; }

        public List<THISINH> GetAll()
        {
            return new DAL_ThiSinh().GetAll();
        }

        public bool Insert(THISINH ThiSinh)
        {
            return new DAL_ThiSinh().Insert(ThiSinh);
        }

        public bool Update(THISINH ThiSinhMoi)
        {
            return new DAL_ThiSinh().Update(ThiSinhMoi);
        }

        public bool Delete(THISINH ThiSinh)
        {
            return new DAL_ThiSinh().Delete(ThiSinh);
        }
    }
}
