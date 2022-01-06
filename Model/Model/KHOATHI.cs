namespace Model.Model
{
    using global::Model.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOATHI")]
    public partial class KHOATHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOATHI()
        {
            DANGKies = new HashSet<DANGKY>();
            PHONGTHIs = new HashSet<PHONGTHI>();
        }

        [Key]
        [StringLength(4)]
        public string MAKHOA { get; set; }

        [Required]
        [StringLength(100)]
        public string TENKHOA { get; set; }

        [DataType(DataType.Date)]
        public DateTime NGAYTHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKY> DANGKies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGTHI> PHONGTHIs { get; set; }

        public List<KHOATHI> GetAll()
        {
            return new DAL_KhoaThi().GetAll();
        }

        public bool Insert(KHOATHI KhoaThi)
        {
            return new DAL_KhoaThi().Insert(KhoaThi);
        }

        public bool Update(KHOATHI KhoaThiMoi)
        {
            return new DAL_KhoaThi().Update(KhoaThiMoi);
        }

        public bool Delete(KHOATHI KhoaThi)
        {
            return new DAL_KhoaThi().Delete(KhoaThi);
        }
    }
}
