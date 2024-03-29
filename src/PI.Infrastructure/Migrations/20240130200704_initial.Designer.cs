﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PI.Infrastructure.Data;

#nullable disable

namespace PI.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240130200704_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PI.Domain.Entity.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("PI.Domain.Entity.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("PI.Domain.Entity.InvestmentPortfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("InvestmentPortfolio");
                });

            modelBuilder.Entity("PI.Domain.Entity.InvestmentPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<int?>("AssetId1")
                        .HasColumnType("int");

                    b.Property<decimal>("AveragePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("InvestmentPortfolioId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("AssetId1");

                    b.HasIndex("InvestmentPortfolioId");

                    b.ToTable("InvestmentPosition");
                });

            modelBuilder.Entity("PI.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("PI.Domain.Entity.BankAccount", b =>
                {
                    b.HasOne("PI.Domain.Entity.User", "User")
                        .WithOne("BankAccount")
                        .HasForeignKey("PI.Domain.Entity.BankAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PI.Domain.Entity.InvestmentPortfolio", b =>
                {
                    b.HasOne("PI.Domain.Entity.User", "User")
                        .WithOne("InvestmentPortfolio")
                        .HasForeignKey("PI.Domain.Entity.InvestmentPortfolio", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PI.Domain.Entity.InvestmentPosition", b =>
                {
                    b.HasOne("PI.Domain.Entity.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PI.Domain.Entity.Asset", null)
                        .WithMany("InvestmentPositions")
                        .HasForeignKey("AssetId1");

                    b.HasOne("PI.Domain.Entity.InvestmentPortfolio", "InvestmentPortfolio")
                        .WithMany("Positions")
                        .HasForeignKey("InvestmentPortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("InvestmentPortfolio");
                });

            modelBuilder.Entity("PI.Domain.Entity.Asset", b =>
                {
                    b.Navigation("InvestmentPositions");
                });

            modelBuilder.Entity("PI.Domain.Entity.InvestmentPortfolio", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("PI.Domain.Entity.User", b =>
                {
                    b.Navigation("BankAccount")
                        .IsRequired();

                    b.Navigation("InvestmentPortfolio")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
