using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Dreamlines.Models.Configurations {

    public class CurrencyTypeConfiguration : IEntityTypeConfiguration<Currency> {

        public void Configure(EntityTypeBuilder<Currency> builder) {
            builder.ToTable("currency");

            builder.Property(e => e.Id)
                   .HasColumnName("currency_id");

            builder.Property(e => e.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(e => e.Name)
                   .HasName("ix_currency_name")
                   .IsUnique();

            builder.Property(e => e.Symbol)
                   .HasColumnName("symbol")
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(e => e.CreatedOn)
                   .HasColumnName("created_on")
                   .IsRequired();

            builder.HasData(CreateSeedData().ToArray());
        }

        public IEnumerable<Currency> CreateSeedData() {
            yield return new Currency {
                Id = 1,
                Name = "Euro",
                Symbol = "€",
                CreatedOn = DateTime.UtcNow
            };

            yield return new Currency {
                Id = 2,
                Name = "Brazilian real",
                Symbol = "R$",
                CreatedOn = DateTime.UtcNow
            };

            yield return new Currency {
                Id = 3,
                Name = "Australian dollar",
                Symbol = "AU$",
                CreatedOn = DateTime.UtcNow
            };

            yield return new Currency {
                Id = 4,
                Name = "Russian ruble",
                Symbol = "RUB",
                CreatedOn = DateTime.UtcNow
            };

            yield return new Currency {
                Id = 5,
                Name = "Renminbi",
                Symbol = "¥",
                CreatedOn = DateTime.UtcNow
            };
        }

    }
}
