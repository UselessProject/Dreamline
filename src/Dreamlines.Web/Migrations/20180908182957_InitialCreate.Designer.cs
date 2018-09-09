﻿// <auto-generated />
using System;
using Dreamlines.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dreamlines.Web.Migrations
{
    [DbContext(typeof(DreamlinesContext))]
    [Migration("20180908182957_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dreamlines.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("booking_id");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnName("booking_date");

                    b.Property<double>("Price")
                        .HasColumnName("price");

                    b.Property<int>("ShipId")
                        .HasColumnName("ship_id");

                    b.HasKey("Id");

                    b.HasIndex("BookingDate")
                        .HasName("ix_booking_date");

                    b.HasIndex("ShipId");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("Dreamlines.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("country_id");

                    b.Property<int>("CurrencyId")
                        .HasColumnName("currency_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("country");

                    b.HasData(
                        new { Id = 1, CurrencyId = 1, Name = "Germany" },
                        new { Id = 2, CurrencyId = 2, Name = "Brazil" },
                        new { Id = 3, CurrencyId = 1, Name = "Italy" },
                        new { Id = 4, CurrencyId = 1, Name = "France" },
                        new { Id = 5, CurrencyId = 3, Name = "Australia" },
                        new { Id = 6, CurrencyId = 4, Name = "Russia" },
                        new { Id = 7, CurrencyId = 1, Name = "Netherlands" },
                        new { Id = 8, CurrencyId = 5, Name = "China" }
                    );
                });

            modelBuilder.Entity("Dreamlines.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("currency_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnName("symbol")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("ix_currency_name");

                    b.ToTable("currency");

                    b.HasData(
                        new { Id = 1, Name = "Euro", Symbol = "€" },
                        new { Id = 2, Name = "Brazilian real", Symbol = "R$" },
                        new { Id = 3, Name = "Australian dollar", Symbol = "AU$" },
                        new { Id = 4, Name = "Russian ruble", Symbol = "RUB" },
                        new { Id = 5, Name = "Renminbi", Symbol = "¥" }
                    );
                });

            modelBuilder.Entity("Dreamlines.Models.SalesUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sales_unit_id");

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("sales_unit");

                    b.HasData(
                        new { Id = 1, CountryId = 1, Name = "dreamlines.de" },
                        new { Id = 2, CountryId = 2, Name = "dreamlines.com.br" },
                        new { Id = 3, CountryId = 3, Name = "dreamlines.it" },
                        new { Id = 4, CountryId = 4, Name = "dreamlines.fr" },
                        new { Id = 5, CountryId = 5, Name = "dreamlines.com.au" },
                        new { Id = 6, CountryId = 6, Name = "dreamlines.ru" },
                        new { Id = 7, CountryId = 7, Name = "dreamlines.nl" },
                        new { Id = 8, CountryId = 8, Name = "soyoulun.com" }
                    );
                });

            modelBuilder.Entity("Dreamlines.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ship_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<int>("SalesUnitId")
                        .HasColumnName("sales_unit_id");

                    b.HasKey("Id");

                    b.HasIndex("SalesUnitId")
                        .HasName("ix_sales_unit_id");

                    b.ToTable("ship");
                });

            modelBuilder.Entity("Dreamlines.Models.Booking", b =>
                {
                    b.HasOne("Dreamlines.Models.Ship", "Ship")
                        .WithMany("Booking")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dreamlines.Models.Country", b =>
                {
                    b.HasOne("Dreamlines.Models.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dreamlines.Models.SalesUnit", b =>
                {
                    b.HasOne("Dreamlines.Models.Country", "Country")
                        .WithMany("SalesUnits")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dreamlines.Models.Ship", b =>
                {
                    b.HasOne("Dreamlines.Models.SalesUnit", "SalesUnit")
                        .WithMany("Ships")
                        .HasForeignKey("SalesUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
