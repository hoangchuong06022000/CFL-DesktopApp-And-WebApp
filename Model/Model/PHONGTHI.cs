namespace Model.Model
{
    using global::Model.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGTHI")]
    public partial class PHONGTHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONGTHI()
        {
            DSTHISINHTHEOPHONGs = new HashSet<DSTHISINHTHEOPHONG>();
            GIAOVIENs = new HashSet<GIAOVIEN>();
        }

        [Key]
        [StringLength(4)]
        public string MAPHONG { get; set; }

        [Required]
        [StringLength(4)]
        public string MAKHOA { get; set; }

        [Required]
        [StringLength(5)]
        public string TENPHONG { get; set; }

        [Required]
        [StringLength(2)]
        public string TRINHDO { get; set; }

        [Required]
        [StringLength(50)]
        public string CATHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSTHISINHTHEOPHONG> DSTHISINHTHEOPHONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAOVIEN> GIAOVIENs { get; set; }

        public virtual KHOATHI KHOATHI { get; set; }

        public List<PHONGTHI> GetPhongThi(string MaKhoa)
        {
            return new DAL_PhongThi().GetPhongThi(MaKhoa);
        }
        public List<PHONGTHI> GetAll()
        {
            return new DAL_PhongThi().GetAll();
        }
        public bool Insert(PHONGTHI PhongThi)
        {
            return new DAL_PhongThi().Insert(PhongThi);
        }

        public bool Update(PHONGTHI PhongThiMoi)
        {
            return new DAL_PhongThi().Update(PhongThiMoi);
        }

        public bool Delete(PHONGTHI PhongThi)
        {
            return new DAL_PhongThi().Delete(PhongThi);
        }
    }
}
