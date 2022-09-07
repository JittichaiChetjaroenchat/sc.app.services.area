﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SC.App.Services.Area.Database;

namespace SC.App.Services.Area.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220118053245_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("SC.App.Services.Area.Database.Models.Area", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("district");

                    b.Property<bool>("IsCapital")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_capital");

                    b.Property<bool>("IsPerimeter")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_perimeter");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("province");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("region_id");

                    b.Property<string>("SubDistrict")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("sub_district");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("Province", "District", "SubDistrict", "PostalCode")
                        .IsUnique();

                    b.ToTable("areas");
                });

            modelBuilder.Entity("SC.App.Services.Area.Database.Models.Region", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("description");

                    b.Property<int>("Index")
                        .HasColumnType("int")
                        .HasColumnName("index");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("regions");

                    b.HasData(
                        new
                        {
                            Id = "7c309c8d-f3b7-a3c4-2822-a51922d1ceaa",
                            Code = "N",
                            Description = "North",
                            Index = 1
                        },
                        new
                        {
                            Id = "6c0633dc-9339-d5e0-0896-e533fd692ce0",
                            Code = "NE",
                            Description = "North East",
                            Index = 2
                        },
                        new
                        {
                            Id = "6ec0e961-a8a9-505a-88a4-99df6458d276",
                            Code = "W",
                            Description = "West",
                            Index = 3
                        },
                        new
                        {
                            Id = "37f8610d-ad0c-411d-2f80-b84d143e1257",
                            Code = "C",
                            Description = "Central",
                            Index = 4
                        },
                        new
                        {
                            Id = "0ca03e3a-35fc-2c33-edf6-e5e9a32e94da",
                            Code = "E",
                            Description = "East",
                            Index = 5
                        },
                        new
                        {
                            Id = "dc98bc5d-83c9-07a7-28bd-082d1a47546e",
                            Code = "S",
                            Description = "South",
                            Index = 6
                        });
                });

            modelBuilder.Entity("SC.App.Services.Area.Database.Models.Area", b =>
                {
                    b.HasOne("SC.App.Services.Area.Database.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
