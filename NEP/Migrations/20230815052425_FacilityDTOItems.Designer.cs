﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NEP.Data;

#nullable disable

namespace NEP.Migrations
{
    [DbContext(typeof(NEPContext))]
    [Migration("20230815052425_FacilityDTOItems")]
    partial class FacilityDTOItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NEP.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("NEP.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsIndoor")
                        .HasColumnType("bit");

                    b.Property<string>("Lines")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nets")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("NEP.Models.CourtColors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourtColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<string>("KitchenColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OBColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourtId")
                        .IsUnique();

                    b.ToTable("CourtColors");
                });

            modelBuilder.Entity("NEP.Models.DiningFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BeerAndWine")
                        .HasColumnType("bit");

                    b.Property<bool>("Delivery")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DineIn")
                        .HasColumnType("bit");

                    b.Property<string>("DiningFacilityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<bool>("FullLiquor")
                        .HasColumnType("bit");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Menu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Reservations")
                        .HasColumnType("bit");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("DiningFacilities");
                });

            modelBuilder.Entity("NEP.Models.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("NEP.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BeverageOther")
                        .HasColumnType("bit");

                    b.Property<bool>("Beverages")
                        .HasColumnType("bit");

                    b.Property<bool>("CarCharge")
                        .HasColumnType("bit");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtIconImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DropIns")
                        .HasColumnType("bit");

                    b.Property<string>("FacilityCourtIconImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Fee")
                        .HasColumnType("float");

                    b.Property<bool>("HasProShop")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<bool>("Lights")
                        .HasColumnType("bit");

                    b.Property<bool>("LockerRooms")
                        .HasColumnType("bit");

                    b.Property<double?>("MembershipDiscountFee")
                        .HasColumnType("float");

                    b.Property<double?>("MembershipFee")
                        .HasColumnType("float");

                    b.Property<bool>("Memberships")
                        .HasColumnType("bit");

                    b.Property<string>("NEPMembershipDiscount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NEPPartner")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Parking")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Picnic")
                        .HasColumnType("bit");

                    b.Property<bool>("Playground")
                        .HasColumnType("bit");

                    b.Property<int?>("ProShopId")
                        .HasColumnType("int");

                    b.Property<bool>("Reservations")
                        .HasColumnType("bit");

                    b.Property<bool>("RestRooms")
                        .HasColumnType("bit");

                    b.Property<bool>("Showers")
                        .HasColumnType("bit");

                    b.Property<bool>("Snacks")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WaterFountain")
                        .HasColumnType("bit");

                    b.Property<bool>("hasCorporateRetreats")
                        .HasColumnType("bit");

                    b.Property<bool>("hasLeaguePlay")
                        .HasColumnType("bit");

                    b.Property<bool>("hasPartyBooking")
                        .HasColumnType("bit");

                    b.Property<bool>("hasSpecialEvents")
                        .HasColumnType("bit");

                    b.Property<bool>("hasTournaments")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ProShopId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("NEP.Models.Financial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Financials");
                });

            modelBuilder.Entity("NEP.Models.HoursOfDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiningFacilityId")
                        .HasColumnType("int");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("HoursOfOperation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiningFacilityId");

                    b.ToTable("HoursOfDeliveries");
                });

            modelBuilder.Entity("NEP.Models.HoursOfFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiningFacilityId")
                        .HasColumnType("int");

                    b.Property<string>("HoursOfOperation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiningFacilityId");

                    b.ToTable("HoursOfFood");
                });

            modelBuilder.Entity("NEP.Models.HoursOfPlay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("Hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.ToTable("HoursOfPlay");
                });

            modelBuilder.Entity("NEP.Models.HoursOfProShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HoursOfOperation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProShopId")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProShopId");

                    b.ToTable("HoursOfProShops");
                });

            modelBuilder.Entity("NEP.Models.Mailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MailerTypeId")
                        .HasColumnType("int")
                        .HasColumnName("MailerTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mailers");
                });

            modelBuilder.Entity("NEP.Models.MailerSignature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MailerSignatures");
                });

            modelBuilder.Entity("NEP.Models.MailerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MailerSignatureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MailerTypes");
                });

            modelBuilder.Entity("NEP.Models.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("NEP.Models.ProShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MembershipDiscount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NEPMembershipDiscount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProShops");
                });

            modelBuilder.Entity("NEP.Models.SkillLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankSequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("NEP.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("NEP.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AddressId");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewsletter")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReferredById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ReferredById");

                    b.Property<Guid?>("SkillLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SkillLevelIsVerified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NEP.Models.UserMailerType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("MailerTypeId")
                        .HasColumnType("int")
                        .HasColumnName("MailerTypeId");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserMailerTypes");
                });

            modelBuilder.Entity("NEP.Models.Address", b =>
                {
                    b.HasOne("NEP.Models.State", "State")
                        .WithMany("Addresses")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("NEP.Models.Court", b =>
                {
                    b.HasOne("NEP.Models.Facility", "Facility")
                        .WithMany("Courts")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("NEP.Models.CourtColors", b =>
                {
                    b.HasOne("NEP.Models.Court", "Court")
                        .WithOne("CourtColors")
                        .HasForeignKey("NEP.Models.CourtColors", "CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");
                });

            modelBuilder.Entity("NEP.Models.DiningFacility", b =>
                {
                    b.HasOne("NEP.Models.Facility", "Facility")
                        .WithMany("DiningFacilities")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("NEP.Models.Facility", b =>
                {
                    b.HasOne("NEP.Models.Address", "Address")
                        .WithMany("Facilities")
                        .HasForeignKey("AddressId");

                    b.HasOne("NEP.Models.ProShop", "ProShop")
                        .WithMany()
                        .HasForeignKey("ProShopId");

                    b.Navigation("Address");

                    b.Navigation("ProShop");
                });

            modelBuilder.Entity("NEP.Models.HoursOfDelivery", b =>
                {
                    b.HasOne("NEP.Models.DiningFacility", "DiningFacility")
                        .WithMany("HoursOfDelivery")
                        .HasForeignKey("DiningFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiningFacility");
                });

            modelBuilder.Entity("NEP.Models.HoursOfFood", b =>
                {
                    b.HasOne("NEP.Models.DiningFacility", "DiningFacility")
                        .WithMany("HoursOfFood")
                        .HasForeignKey("DiningFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiningFacility");
                });

            modelBuilder.Entity("NEP.Models.HoursOfPlay", b =>
                {
                    b.HasOne("NEP.Models.Court", "Court")
                        .WithMany("HoursOfPlay")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");
                });

            modelBuilder.Entity("NEP.Models.HoursOfProShop", b =>
                {
                    b.HasOne("NEP.Models.ProShop", "ProShop")
                        .WithMany("Hours")
                        .HasForeignKey("ProShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProShop");
                });

            modelBuilder.Entity("NEP.Models.User", b =>
                {
                    b.HasOne("NEP.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("NEP.Models.Address", b =>
                {
                    b.Navigation("Facilities");
                });

            modelBuilder.Entity("NEP.Models.Court", b =>
                {
                    b.Navigation("CourtColors")
                        .IsRequired();

                    b.Navigation("HoursOfPlay");
                });

            modelBuilder.Entity("NEP.Models.DiningFacility", b =>
                {
                    b.Navigation("HoursOfDelivery");

                    b.Navigation("HoursOfFood");
                });

            modelBuilder.Entity("NEP.Models.Facility", b =>
                {
                    b.Navigation("Courts");

                    b.Navigation("DiningFacilities");
                });

            modelBuilder.Entity("NEP.Models.ProShop", b =>
                {
                    b.Navigation("Hours");
                });

            modelBuilder.Entity("NEP.Models.State", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
