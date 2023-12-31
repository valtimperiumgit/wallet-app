﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletApp.Persistence.DBContext;

#nullable disable

namespace WalletApp.Persistence.Migrations
{
    [DbContext(typeof(WalletAppDbContext))]
    [Migration("20231109151639_Inits")]
    partial class Inits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletApp.Domain.Entities.TransactionNamespace.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("AuthorizedUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPending")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2c8222f-e19d-401e-94df-f9ddeae2fd24"),
                            Amount = 500m,
                            AuthorizedUserId = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                            CreatedAt = new DateTime(2023, 10, 9, 4, 2, 3, 0, DateTimeKind.Utc),
                            Description = "From ATM Los Angeles",
                            IconUrl = "https://cdn-icons-png.flaticon.com/512/6059/6059866.png",
                            IsPending = false,
                            Name = "ATM Los Angeles",
                            Type = 1,
                            UserId = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527")
                        },
                        new
                        {
                            Id = new Guid("ba8ac6fc-e17d-4616-9fd7-e42caadcd3cf"),
                            Amount = 21.61m,
                            AuthorizedUserId = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                            CreatedAt = new DateTime(2023, 11, 9, 1, 2, 3, 0, DateTimeKind.Utc),
                            Description = "Round Rock, Tc",
                            IconUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThmMLqHvT1CtfTxVLZB3Uhg3GyH7loVRDQFg&usqp=CAU",
                            IsPending = false,
                            Name = "IKEA",
                            Type = 2,
                            UserId = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527")
                        },
                        new
                        {
                            Id = new Guid("b40f6bfa-5bca-43ba-92e0-75a003c90b19"),
                            Amount = 43.61m,
                            AuthorizedUserId = new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                            CreatedAt = new DateTime(2023, 11, 9, 4, 5, 6, 0, DateTimeKind.Utc),
                            Description = "Card Number Used",
                            IconUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141",
                            IsPending = false,
                            Name = "Apple",
                            Type = 2,
                            UserId = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527")
                        },
                        new
                        {
                            Id = new Guid("fe0f415c-064f-4591-b45d-328380bfa076"),
                            Amount = 1000m,
                            AuthorizedUserId = new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                            CreatedAt = new DateTime(2023, 11, 9, 8, 7, 6, 0, DateTimeKind.Utc),
                            Description = "Some payment",
                            IconUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141",
                            IsPending = false,
                            Name = "Payment",
                            Type = 1,
                            UserId = new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae")
                        });
                });

            modelBuilder.Entity("WalletApp.Domain.Entities.UserNamespace.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                            Email = "test@gmail.com",
                            Name = "Test",
                            Password = "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec"
                        },
                        new
                        {
                            Id = new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                            Email = "friend@gmail.com",
                            Name = "Friend",
                            Password = "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec"
                        });
                });

            modelBuilder.Entity("WalletApp.Domain.Entities.TransactionNamespace.Transaction", b =>
                {
                    b.HasOne("WalletApp.Domain.Entities.UserNamespace.User", "AuthorizedUser")
                        .WithMany()
                        .HasForeignKey("AuthorizedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WalletApp.Domain.Entities.UserNamespace.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorizedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WalletApp.Domain.Entities.UserNamespace.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
