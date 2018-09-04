using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Web.Models.Configurations {

    public class CountryTypeConfiguration : IEntityTypeConfiguration<Country> {

        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.ToTable("country");

            builder.Property(e => e.Id)
                   .HasColumnName("country_id");

            builder.Property(e => e.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(e => e.Name)
                   .HasName("ix_country_name")
                   .IsUnique();

            builder.Property(e => e.CurrencyId)
                   .HasColumnName("currency_id")
                   .IsRequired();

            builder.Property(e => e.CreatedOn)
                   .HasColumnName("created_on")
                   .IsRequired();

            builder.HasOne(e => e.Currency)
                   .WithMany(e => e.Countries)
                   .IsRequired();
        }

    }

}
