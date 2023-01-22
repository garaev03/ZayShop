using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zay.Entities.Concrets;

namespace Zay.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SpecialService> SpecialServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpesification> ProductSpesifications { get; set; }
        public DbSet<ProductSizeColorDiscount> ProductSizeColorDiscounts { get; set; }

    }
}
