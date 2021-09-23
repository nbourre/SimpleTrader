﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleTrader.EF;

namespace SimpleTrader.EF.Migrations
{
    [DbContext(typeof(SimpleTraderDbContext))]
    [Migration("20210923145752_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("SimplerTrader.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountHolderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SimplerTrader.Domain.Models.AssetTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPurchase")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Shares")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AssetTransactions");
                });

            modelBuilder.Entity("SimplerTrader.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimplerTrader.Domain.Models.Account", b =>
                {
                    b.HasOne("SimplerTrader.Domain.Models.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");

                    b.Navigation("AccountHolder");
                });

            modelBuilder.Entity("SimplerTrader.Domain.Models.AssetTransaction", b =>
                {
                    b.HasOne("SimplerTrader.Domain.Models.Account", "Account")
                        .WithMany("AssetTransactions")
                        .HasForeignKey("AccountId");

                    b.OwnsOne("SimplerTrader.Domain.Models.Stock", "Stock", b1 =>
                        {
                            b1.Property<int>("AssetTransactionId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("PricePerShare")
                                .HasColumnType("REAL");

                            b1.Property<string>("Symbol")
                                .HasColumnType("TEXT");

                            b1.HasKey("AssetTransactionId");

                            b1.ToTable("AssetTransactions");

                            b1.WithOwner()
                                .HasForeignKey("AssetTransactionId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("SimplerTrader.Domain.Models.Account", b =>
                {
                    b.Navigation("AssetTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
