﻿// <auto-generated />
using _3DPrintingBlockchainMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace _3DPrintingBlockchainMarket.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180204114703_morestudtodaa")]
    partial class morestudtodaa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid?>("EnterpriseIdEnterprise");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseIdEnterprise");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.AuthorizationToken", b =>
                {
                    b.Property<Guid>("IdAuthToken")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthUserId");

                    b.Property<Guid>("ConsumableLicenseId");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateExpires");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedById");

                    b.Property<Guid>("ObjectModeId");

                    b.HasKey("IdAuthToken");

                    b.HasIndex("AuthUserId");

                    b.HasIndex("ConsumableLicenseId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("ObjectModeId");

                    b.ToTable("Authorization_Token");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ConsumableLicense", b =>
                {
                    b.Property<Guid>("IdConsumableLicense")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedById");

                    b.Property<Guid>("ModelLicenseId");

                    b.Property<int>("NumberOfUses");

                    b.Property<Guid>("ObjectModelId");

                    b.HasKey("IdConsumableLicense");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("ModelLicenseId");

                    b.HasIndex("ObjectModelId");

                    b.ToTable("Consumable_License");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.Enterprise", b =>
                {
                    b.Property<Guid>("IdEnterprise")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("LastModifiedById");

                    b.Property<string>("Name");

                    b.Property<string>("VerifiedById");

                    b.HasKey("IdEnterprise");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("VerifiedById");

                    b.ToTable("Enterprise");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ModelLicense", b =>
                {
                    b.Property<Guid>("IdLicense")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<DateTime>("DateValidUnil");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("IdLicense");

                    b.ToTable("Model_License");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ObjectModel", b =>
                {
                    b.Property<Guid>("IdObjectModel")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<int>("DownloadCount");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedById");

                    b.Property<Guid>("ModelLicenseId");

                    b.Property<string>("Name");

                    b.Property<string>("ObjectHash");

                    b.Property<string>("ObjectTags");

                    b.Property<string>("PricingUnitOfMeaureId");

                    b.Property<string>("StoredFileLocation");

                    b.Property<decimal?>("TokenPrice");

                    b.HasKey("IdObjectModel");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("ModelLicenseId");

                    b.HasIndex("PricingUnitOfMeaureId");

                    b.ToTable("Object_Model");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.UnitOfMeasure", b =>
                {
                    b.Property<string>("IdUnitOfMeasure")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateInactivted");

                    b.Property<DateTime>("DateLastModified");

                    b.Property<string>("Description");

                    b.Property<int>("Factor");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("IdUnitOfMeasure");

                    b.ToTable("Unit_Of_Measure");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Role_Claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("User_Claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("User_External_Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("User_Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("User_Token");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole<string>");


                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator().HasValue("IdentityRole");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ApplicationUser", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.Enterprise")
                        .WithMany("Employees")
                        .HasForeignKey("EnterpriseIdEnterprise");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.AuthorizationToken", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "AuthUser")
                        .WithMany("AuthorizationTokens")
                        .HasForeignKey("AuthUserId");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ConsumableLicense", "ConsumableLicense")
                        .WithMany("AuthorizationTokens")
                        .HasForeignKey("ConsumableLicenseId");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "CreatedBy")
                        .WithMany("AuthorizationTokenCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "LastModifiedBy")
                        .WithMany("AuthorizationTokenLastModifiedBy")
                        .HasForeignKey("LastModifiedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ObjectModel", "ObjectModel")
                        .WithMany("AuthorizationTokens")
                        .HasForeignKey("ObjectModeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ConsumableLicense", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "CreatedBy")
                        .WithMany("ConsumableLicensesCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "LastModifiedBy")
                        .WithMany("ConsumableLicensesLastMod")
                        .HasForeignKey("LastModifiedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ModelLicense", "ModelLicense")
                        .WithMany("DistributedLicenses")
                        .HasForeignKey("ModelLicenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ObjectModel", "ObjectModel")
                        .WithMany("ConsumableLicenses")
                        .HasForeignKey("ObjectModelId");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.Enterprise", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "CreatedBy")
                        .WithMany("EnterpriseCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "LastModifiedBy")
                        .WithMany("EnterpriseLastModBy")
                        .HasForeignKey("LastModifiedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "VerifiedBy")
                        .WithMany("EnterpriseVerifiedByUser")
                        .HasForeignKey("VerifiedById");
                });

            modelBuilder.Entity("_3DPrintingBlockchainMarket.Models.ObjectModel", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "CreatedBy")
                        .WithMany("ObjectModelCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser", "LastModifiedBy")
                        .WithMany("ObjectModelLastModBy")
                        .HasForeignKey("LastModifiedById");

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ModelLicense", "ModelLicense")
                        .WithMany("ObjectModelsUnderThisLicense")
                        .HasForeignKey("ModelLicenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_3DPrintingBlockchainMarket.Models.UnitOfMeasure", "PricingUnitOfMeaure")
                        .WithMany("ObjectModelPricingUOM")
                        .HasForeignKey("PricingUnitOfMeaureId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("_3DPrintingBlockchainMarket.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
