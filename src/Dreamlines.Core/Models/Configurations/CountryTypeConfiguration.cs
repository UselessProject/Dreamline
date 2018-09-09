using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Models.Configurations {

    public class CountryTypeConfiguration : IEntityTypeConfiguration<Country> {

        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.ToTable("country");

            builder
                .Property(e => e.Id)
                .HasColumnName("country_id");

            builder
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.CurrencyId)
                .HasColumnName("currency_id")
                .IsRequired();

            builder
                .HasOne(e => e.Currency)
                .WithMany(e => e.Countries);

            builder.HasData(CreateSeedData().ToArray());
        }


        public IEnumerable<Country> CreateSeedData() {
            yield return new Country {
                Id = 1,
                Name = "Germany",
                CurrencyId = 1
            };

            yield return new Country {
                Id = 2,
                Name = "Brazil",
                CurrencyId = 2
            };

            yield return new Country {
                Id = 3,
                Name = "Italy",
                CurrencyId = 1
            };

            yield return new Country {
                Id = 4,
                Name = "France",
                CurrencyId = 1
            };

            yield return new Country {
                Id = 5,
                Name = "Australia",
                CurrencyId = 3
            };

            yield return new Country {
                Id = 6,
                Name = "Russia",
                CurrencyId = 4
            };

            yield return new Country {
                Id = 7,
                Name = "Netherlands",
                CurrencyId = 1
            };

            yield return new Country {
                Id = 8,
                Name = "China",
                CurrencyId = 5
            };
        }

    }

}