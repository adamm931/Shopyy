using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopyy.Infrastructure.Postgres;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;
using Shopyy.Products.Infrastructure.Options;

namespace Shopyy.Products.Infrastructure
{
    public class ProductsDbContext : BaseDbContext
    {
        private readonly IOptions<ProductsCatalogueDatabaseOptions> _options;

        public ProductsDbContext(IOptions<ProductsCatalogueDatabaseOptions> options)
        {
            _options = options;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyCode> CurrencyCodes { get; set; }

        public DbSet<ProductAttributeType> ProductAttributeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_options.Value.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsInfrastructureAssemblyReference).Assembly);

            modelBuilder
                .HasSequence(Sequnces.ProductSerialNumber)
                .StartsAt(Sequnces.ProductSerialStart);
        }
    }
}
