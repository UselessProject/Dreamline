using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dreamlines.Models.Configurations {

    public class SalesUnitTypeConfiguration : IEntityTypeConfiguration<SalesUnit> {

        public void Configure(EntityTypeBuilder<SalesUnit> builder) {
            builder.ToTable("sales_unit");

            builder
                .Property(e => e.Id)
                .HasColumnName("sales_unit_id");

            builder
                .Property(e => e.CountryId)
                .HasColumnName("country_id")
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasName("ix_sales_unit_name");

            builder
                .HasOne(e => e.Country)
                .WithMany(e => e.SalesUnits);

            builder.HasData(CreateSeedData().ToArray());
        }

        public IEnumerable<SalesUnit> CreateSeedData() {
            yield return new SalesUnit {
                Id = 1,
                Name = "dreamlines.de",
                CountryId = 1
            };
            
            yield return new SalesUnit {
                Id = 2,
                Name = "dreamlines.com.br",
                CountryId = 2
            };
            
            yield return new SalesUnit {
                Id = 3,
                Name = "dreamlines.it",
                CountryId = 3
            };
            
            yield return new SalesUnit {
                Id = 4,
                Name = "dreamlines.fr",
                CountryId = 4
            };
            
            yield return new SalesUnit {
                Id = 5,
                Name = "dreamlines.com.au",
                CountryId = 5
            };
            
            yield return new SalesUnit {
                Id = 6,
                Name = "dreamlines.ru",
                CountryId = 6
            };
            
            yield return new SalesUnit {
                Id = 7,
                Name = "dreamlines.nl",
                CountryId = 7
            };
            
            yield return new SalesUnit {
                Id = 8,
                Name = "soyoulun.com",
                CountryId = 8
            };
        }

    }

}