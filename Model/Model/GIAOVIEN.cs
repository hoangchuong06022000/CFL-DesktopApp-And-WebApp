namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [Key]
        [StringLength(5)]
        public string MAGV { get; set; }

        [Required]
        [StringLength(4)]
        public string MAPHONG { get; set; }

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        public virtual PHONGTHI PHONGTHI { get; set; }
    }
}
