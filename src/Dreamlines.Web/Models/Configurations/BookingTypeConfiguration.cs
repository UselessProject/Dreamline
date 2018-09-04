using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Web.Models.Configurations {

    public class BookingTypeConfiguration : IEntityTypeConfiguration<Booking> {

        public void Configure(EntityTypeBuilder<Booking> builder) {
            builder.ToTable("booking");

            builder.Property(e => e.Id)
                   .HasColumnName("booking_id");

            builder.Property(e => e.ShipId)
                   .HasColumnName("ship_id")
                   .IsRequired();

            builder.Property(e => e.BookingDate)
                   .HasColumnName("booking_date")
                   .IsRequired();

            builder.HasIndex(e => e.BookingDate)
                   .IsUnique()
                   .HasName("ix_booking_date");

            builder.Property(e => e.Price)
                   .HasColumnName("price")
                   .IsRequired();

            builder.Property(e => e.CreatedOn)
                   .HasColumnName("created_on")
                   .IsRequired();

            builder.HasOne(e => e.Ship)
                   .WithMany(e => e.Booking)
                   .IsRequired();
        }

    }

}
