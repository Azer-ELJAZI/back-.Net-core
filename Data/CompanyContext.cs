using Microsoft.EntityFrameworkCore;
using stage1.Models;

namespace stage1.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<ServiceCase> ServiceCases { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<ProductFamily> ProductFamilies { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.ProductFamily)
                .WithMany(pf => pf.Articles)
                .HasForeignKey(a => a.ProductFamilyID);

            base.OnModelCreating(modelBuilder);
        }




    }
}
