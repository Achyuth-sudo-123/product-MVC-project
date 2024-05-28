using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace productMVCproject.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<BrandTable> BrandTables { get; set; }
        public virtual DbSet<CategoriTable> CategoriTables { get; set; }
        public virtual DbSet<productTable> productTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandTable>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<BrandTable>()
                .HasMany(e => e.productTables)
                .WithOptional(e => e.BrandTable)
                .HasForeignKey(e => e.brand_id);

            modelBuilder.Entity<CategoriTable>()
                .Property(e => e.Catogori)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriTable>()
                .HasMany(e => e.productTables)
                .WithOptional(e => e.CategoriTable)
                .HasForeignKey(e => e.categori_id);
        }
    }
}
