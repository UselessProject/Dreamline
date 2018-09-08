using Dreamlines.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dreamlines.Models {

    public class DreamlinesContext : DbContext {

        public DreamlinesContext(DbContextOptions<DreamlinesContext> options) 
            : base(options) { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SalesUnit> SalesUnits { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CurrencyTypeConfiguration())
                        .ApplyConfiguration(new CountryTypeConfiguration())
                        .ApplyConfiguration(new SalesUnitTypeConfiguration())
                        .ApplyConfiguration(new ShipTypeConfiguration())
                        .ApplyConfiguration(new BookingTypeConfiguration());
        }

    }

}
