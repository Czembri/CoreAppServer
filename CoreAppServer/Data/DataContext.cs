using API.Entities;
using API.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReceiptPosition> ReceiptPosition { get; set; }
        public DbSet<VatRate> VatRate { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
        public DbSet<Browser> Browser { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ConstitutionChat> ConstitutionChat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Receipt>()
            //    .Navigation(e => e.AppUser).AutoInclude(); // for fun
            modelBuilder.Entity<AppUser>()
            .HasOne(a => a.UserInfo)
            .WithOne(a => a.AppUser)
            .HasForeignKey<UserInfo>(c => c.UserId);

            modelBuilder.Entity<AppUser>()
            .HasMany(a => a.UserRole)
            .WithOne(a => a.AppUser)
            .HasForeignKey(c => c.UserId);

            using var hmac = new HMACSHA512();
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                Id = 1,
                Address = "",
                City = "",
                FirstName = "Admin",
                LastName = "",
                PostalCode = "",
                UserId = 1,
            });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, Role = Role.Admin, UserId = 1 });
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Admin",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                    PasswordSalt = hmac.Key,
                });
            
            modelBuilder.Entity<Product>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("CURRENT_DATE");
           
            modelBuilder.Entity<Product>()
               .Property(b => b.ModificationDate)
               .HasDefaultValueSql("CURRENT_DATE");

        }
    }
}