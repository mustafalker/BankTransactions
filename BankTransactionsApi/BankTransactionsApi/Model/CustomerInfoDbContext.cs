using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BankTransactionsApi.Model
{
    public class CustomerInfoDbContext : DbContext
    {
        public DbSet<CustomerInfo> CustomerInfos { get; set; }

        public CustomerInfoDbContext(DbContextOptions<CustomerInfoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerInfo>()
                .Property(c => c.Type)
                .HasConversion<string>(); // enum tipini string olarak dönüştür

            modelBuilder.Entity<CustomerInfo>()
                .HasCheckConstraint("CK_CustomerInfos_Type", "[Type] IN ('Normal', 'Senior', 'Corporate')"); // Sadece belirli değerleri kabul et
        }
    }
}
