using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Models.Configurations {

    public class ShipTypeConfiguration : IEntityTypeConfiguration<Ship> {

        public void Configure(EntityTypeBuilder<Ship> builder) {
            builder.ToTable("ship");

            builder.Property(e => e.Id)
                   .HasColumnName("ship_id");

            builder.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(e => e.SalesUnitId)
                   .IsUnique()
                   .HasName("ix_sales_unit_id");

            builder.Property(e => e.SalesUnitId)
                   .HasColumnName("sales_unit_id")
                   .IsRequired();

            builder.HasOne(e => e.SalesUnit)
                   .WithMany(e => e.Ships)
                   .IsRequired();
        }

    }

}
