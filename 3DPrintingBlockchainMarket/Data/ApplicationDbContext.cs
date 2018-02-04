using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _3DPrintingBlockchainMarket.Models;
using Microsoft.AspNetCore.Identity;

namespace _3DPrintingBlockchainMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ObjectModel> ObjectModel { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<ModelLicense> ModelLicense { get; set; }
        public virtual DbSet<AuthorizationToken> AuthorizationToken { get; set; }
        public virtual DbSet<ConsumableLicense> ConsumableLicense { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Rename EF user tables to the naming convention
            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<IdentityRole<string>>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("User_Role");
            builder.Entity<IdentityUserToken<string>>().ToTable("User_Token");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Role_Claim");
            builder.Entity<IdentityUserClaim<string>>().ToTable("User_Claim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("User_External_Login");
            //

            //Define and name the custom objects via fluent API
            builder.Entity<ObjectModel>(entity =>
            {
                entity.ToTable("Object_Model");
                entity.HasKey(e => e.IdObjectModel);
                entity.Property(e => e.IdObjectModel)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.ModelLicense)
                    .WithMany(e => e.ObjectModelsUnderThisLicense)
                    .HasForeignKey(e => e.ModelLicenseId);

                entity.HasOne(e => e.PricingUnitOfMeaure)
                    .WithMany(e => e.ObjectModelPricingUOM)
                    .HasForeignKey(e => e.PricingUnitOfMeaureId);

                //User Editable Properties
                entity.HasOne(e => e.CreatedBy)
                    .WithMany(e => e.ObjectModelCreatedBy)
                    .HasForeignKey(e => e.CreatedById);

                entity.HasOne(e => e.LastModifiedBy)
                    .WithMany(e => e.ObjectModelLastModBy)
                    .HasForeignKey(e => e.LastModifiedById);
            });

            builder.Entity<Enterprise>(entity =>
            {
                //Already named the proper table
                entity.HasKey(e => e.IdEnterprise);
                entity.Property(e => e.IdEnterprise)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.VerifiedBy)
                    .WithMany(e => e.EnterpriseVerifiedByUser)
                    .HasForeignKey(e => e.VerifiedById);

                //User editable props
                entity.HasOne(e => e.CreatedBy)
                    .WithMany(e => e.EnterpriseCreatedBy)
                    .HasForeignKey(e => e.CreatedById);

                entity.HasOne(e => e.LastModifiedBy)
                    .WithMany(e => e.EnterpriseLastModBy)
                    .HasForeignKey(e => e.LastModifiedById);

            });

            builder.Entity<UnitOfMeasure>(entity =>
            {
                entity.ToTable("Unit_Of_Measure");
                entity.HasKey(e => e.IdUnitOfMeasure);

                //no data or user editable
            });

            builder.Entity<ModelLicense>(entity =>
            {
                entity.ToTable("Model_License");
                entity.HasKey(e => e.IdLicense);
                entity.Property(e => e.IdLicense)
                    .ValueGeneratedOnAdd();


            });

            builder.Entity<ConsumableLicense>(entity =>
            {
                entity.ToTable("Consumable_License");
                entity.HasKey(e => e.IdConsumableLicense);
                entity.Property(e => e.IdConsumableLicense)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.ModelLicense)
                    .WithMany(e => e.DistributedLicenses)
                    .HasForeignKey(e => e.ModelLicenseId);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany(e => e.ConsumableLicensesCreatedBy)
                    .HasForeignKey(e => e.CreatedById);

                entity.HasOne(e => e.LastModifiedBy)
                    .WithMany(e => e.ConsumableLicensesLastMod)
                    .HasForeignKey(e => e.LastModifiedById);
            });

            builder.Entity<AuthorizationToken>(entity =>
            {
                entity.ToTable("Authorization_Token");
                entity.HasKey(f => f.IdAuthToken);
                entity.Property(e => e.IdAuthToken)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.ObjectModel)
                    .WithMany(e => e.AuthorizationTokens)
                    .HasForeignKey(e => e.ObjectModeId);

                entity.HasOne(e => e.AuthUser)
                    .WithMany(e => e.AuthorizationTokens)
                    .HasForeignKey(e => e.AuthUserId);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany(e => e.AuthorizationTokenCreatedBy)
                    .HasForeignKey(e => e.CreatedById);

                entity.HasOne(e => e.LastModifiedBy)
                    .WithMany(e => e.AuthorizationTokenLastModifiedBy)
                    .HasForeignKey(e => e.LastModifiedById);
            });
        }
    }
}
