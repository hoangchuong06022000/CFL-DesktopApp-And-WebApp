using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.Model
{
    public partial class QLTTEntity : DbContext
    {
        public QLTTEntity()
            : base("name=QLTT")
        {
        }

        public virtual DbSet<DANGKY> DANGKies { get; set; }
        public virtual DbSet<DSTHISINHTHEOPHONG> DSTHISINHTHEOPHONGs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<KHOATHI> KHOATHIs { get; set; }
        public virtual DbSet<PHONGTHI> PHONGTHIs { get; set; }
        public virtual DbSet<THISINH> THISINHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DANGKY>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DANGKY>()
                .Property(e => e.MAKHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DANGKY>()
                .Property(e => e.TRINHDO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSTHISINHTHEOPHONG>()
                .Property(e => e.UNIQUEID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSTHISINHTHEOPHONG>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSTHISINHTHEOPHONG>()
                .Property(e => e.MAPHONG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSTHISINHTHEOPHONG>()
                .Property(e => e.SBD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MAGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MAPHONG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOATHI>()
                .Property(e => e.MAKHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOATHI>()
                .HasMany(e => e.DANGKies)
                .WithRequired(e => e.KHOATHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHOATHI>()
                .HasMany(e => e.PHONGTHIs)
                .WithRequired(e => e.KHOATHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONGTHI>()
                .Property(e => e.MAPHONG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONGTHI>()
                .Property(e => e.MAKHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONGTHI>()
                .Property(e => e.TENPHONG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONGTHI>()
                .Property(e => e.TRINHDO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONGTHI>()
                .HasMany(e => e.DSTHISINHTHEOPHONGs)
                .WithRequired(e => e.PHONGTHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONGTHI>()
                .HasMany(e => e.GIAOVIENs)
                .WithRequired(e => e.PHONGTHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THISINH>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THISINH>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THISINH>()
                .HasMany(e => e.DANGKies)
                .WithRequired(e => e.THISINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THISINH>()
                .HasMany(e => e.DSTHISINHTHEOPHONGs)
                .WithRequired(e => e.THISINH)
                .WillCascadeOnDelete(false);
        }
    }
}
