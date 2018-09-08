using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Models.Configurations {

    public class SalesUnitTypeConfiguration : IEntityTypeConfiguration<SalesUnit> {

        public void Configure(EntityTypeBuilder<SalesUnit> builder) {
            builder.ToTable("sales_unit");

            builder.Property(e => e.Id)
                .HasColumnName("sales_unit_id");

            builder.Property(e => e.CountryId)
                .HasColumnName("country_id")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .IsRequired();

            builder.HasOne(e => e.Country)
                .WithMany(e => e.SalesUnits)
                .IsRequired();
        }

    }

}