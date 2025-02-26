﻿// <auto-generated />
using System;
using BlazorWeb.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWeb.Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorWeb.Server.Models.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "#FFCD56",
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 2,
                            Color = "#FF6384",
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 3,
                            Color = "#4BC0C0",
                            Name = "Benz"
                        },
                        new
                        {
                            Id = 4,
                            Color = "#FF9124",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 5,
                            Color = "#2B88D8",
                            Name = "Tesla"
                        });
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ConfirmationEmailRequestedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ResetPasswordEmailRequestedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            BirthDate = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            ConcurrencyStamp = "3e496120-43ec-4f42-b607-7cdf2a3cd843",
                            Email = "test@bitplatform.dev",
                            EmailConfirmed = true,
                            FullName = "BlazorWeb test account",
                            Gender = 2,
                            LockoutEnabled = true,
                            NormalizedEmail = "TEST@BITPLATFORM.DEV",
                            NormalizedUserName = "TEST@BITPLATFORM.DEV",
                            PasswordHash = "AQAAAAIAAYagAAAAEBv9z0VdfunYh4mV9x8IJiLvR1WefLnibCf5ugcGZH5E9FstjLa9oQiDMGXDJguDiw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e8c42956-0730-46cb-8e7b-fdcd7acbd4bf",
                            TwoFactorEnabled = false,
                            UserName = "test@bitplatform.dev"
                        });
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "The Ford Mustang is ranked #1 in Sports Cars",
                            Name = "Mustang",
                            Price = 27155m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "The Ford GT is a mid-engine two-seater sports car manufactured and marketed by American automobile manufacturer",
                            Name = "GT",
                            Price = 500000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "Ford Ranger is a nameplate that has been used on multiple model lines of pickup trucks sold by Ford worldwide.",
                            Name = "Ranger",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "Raptor is a SCORE off-road trophy truck living in a asphalt world",
                            Name = "Raptor",
                            Price = 53205m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "The Ford Maverick is a compact pickup truck produced by Ford Motor Company.",
                            Name = "Maverick",
                            Price = 22470m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "A powerful convertible sports car",
                            Name = "Roadster",
                            Price = 42800m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "A perfectly adequate family sedan with sharp looks",
                            Name = "Altima",
                            Price = 24550m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "Legendary supercar with AWD, 4 seats, a powerful V6 engine and the latest tech",
                            Name = "GT-R",
                            Price = 113540m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "A new smart SUV",
                            Name = "Juke",
                            Price = 28100m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "H247",
                            Price = 54950m
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "V297",
                            Price = 103360m
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "R50",
                            Price = 2000000m
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "M550i",
                            Price = 77790m
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "540i",
                            Price = 60945m
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "530e",
                            Price = 56545m
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "530i",
                            Price = 55195m
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "M850i",
                            Price = 100045m
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "X7",
                            Price = 77980m
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "",
                            Name = "IX",
                            Price = 87000m
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 5,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "rapid acceleration and dynamic handling",
                            Name = "Model 3",
                            Price = 61990m
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "finishes near the top of our luxury electric car rankings.",
                            Name = "Model S",
                            Price = 135000m
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "Heart-pumping acceleration, long drive range",
                            Name = "Model X",
                            Price = 138890m
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "extensive driving range, lots of standard safety features",
                            Name = "Model Y",
                            Price = 67790m
                        });
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Todo.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Products.Product", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Categories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Todo.TodoItem", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorWeb.Server.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BlazorWeb.Server.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorWeb.Server.Models.Categories.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
