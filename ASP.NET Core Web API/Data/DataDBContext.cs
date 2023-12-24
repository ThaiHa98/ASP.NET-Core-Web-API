using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class DataDBContext : DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) 
        {
        }
        public DbSet<Staff> Staffs { get; set; }
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
                    .HasKey(pc => new { pc.StaffId, pc.CategoryId });
            modelBuilder.Entity<StaffCategory>()
                    .HasOne(p => p.Staff)
                    .WithMany(pc => pc.StaffCategories)
                    .HasForeignKey(p => p.StaffId);
            modelBuilder.Entity<StaffCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.StaffCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<StaffOwner>()
                    .HasKey(po => new { po.StaffId, po.OwnerId });
            modelBuilder.Entity<StaffOwner>()
                    .HasOne(p => p.Staff)
                    .WithMany(pc => pc.StaffOwners)
                    .HasForeignKey(p => p.StaffId);
            modelBuilder.Entity<StaffOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.StaffOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}
