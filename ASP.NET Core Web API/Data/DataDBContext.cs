using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class DataDBContext : DbContext
    {
        public DataDBContext(DbContextOptions<DbContext> options) : base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<StaffCategory> StaffCategories { get; set;}
        public DbSet<StaffOwner> StaffOwners { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffCategory>()
                .HasKey(c => new { c.StaffId, c.CategoryId});
            modelBuilder.Entity<StaffCategory>()
                .HasOne(pc => pc.Staff)
                .WithMany(b => b.staffCategories)
                .HasForeignKey(c => c.StaffId);
            modelBuilder.Entity<StaffCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.staffCategories)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<StaffOwner>()
                .HasKey(po => new { po.StaffId, po.OwnerId });
            modelBuilder.Entity<StaffCategory>()
                .HasOne(pc => pc.Staff)
                .WithMany(po => po.staffCategories)
                .HasForeignKey(pc => pc.StaffId);
            modelBuilder.Entity<StaffOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.StaffOwner)
                .HasForeignKey(p => p.OwnerId);
        }
    }
}
