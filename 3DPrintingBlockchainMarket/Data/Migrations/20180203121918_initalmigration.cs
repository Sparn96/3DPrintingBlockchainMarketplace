using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _3DPrintingBlockchainMarket.Data.Migrations
{
    public partial class initalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "User_Token");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "User_Role");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "User_External_Login");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "User_Claim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "Role_Claim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "User_Role",
                newName: "IX_User_Role_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "User_External_Login",
                newName: "IX_User_External_Login_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "User_Claim",
                newName: "IX_User_Claim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "Role_Claim",
                newName: "IX_Role_Claim_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseIdEnterprise",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Role",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Token",
                table: "User_Token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Role",
                table: "User_Role",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_External_Login",
                table: "User_External_Login",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Claim",
                table: "User_Claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role_Claim",
                table: "Role_Claim",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    IdEnterprise = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    LastModifiedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VerifiedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.IdEnterprise);
                    table.ForeignKey(
                        name: "FK_Enterprise_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprise_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprise_User_VerifiedById",
                        column: x => x.VerifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Model_License",
                columns: table => new
                {
                    IdLicense = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    DateValidUnil = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model_License", x => x.IdLicense);
                });

            migrationBuilder.CreateTable(
                name: "Unit_Of_Measure",
                columns: table => new
                {
                    IdUnitOfMeasure = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Factor = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit_Of_Measure", x => x.IdUnitOfMeasure);
                });

            migrationBuilder.CreateTable(
                name: "Object_Model",
                columns: table => new
                {
                    IdObjectModel = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    DownloadCount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModifiedById = table.Column<string>(nullable: true),
                    ModelLicenseId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ObjectHash = table.Column<string>(nullable: true),
                    ObjectTags = table.Column<string>(nullable: true),
                    PricingUnitOfMeaureId = table.Column<string>(nullable: true),
                    StoredFileLocation = table.Column<string>(nullable: true),
                    TokenPrice = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_Model", x => x.IdObjectModel);
                    table.ForeignKey(
                        name: "FK_Object_Model_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Object_Model_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Object_Model_Model_License_ModelLicenseId",
                        column: x => x.ModelLicenseId,
                        principalTable: "Model_License",
                        principalColumn: "IdLicense",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_Model_Unit_Of_Measure_PricingUnitOfMeaureId",
                        column: x => x.PricingUnitOfMeaureId,
                        principalTable: "Unit_Of_Measure",
                        principalColumn: "IdUnitOfMeasure",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_EnterpriseIdEnterprise",
                table: "User",
                column: "EnterpriseIdEnterprise");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_CreatedById",
                table: "Enterprise",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_LastModifiedById",
                table: "Enterprise",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_VerifiedById",
                table: "Enterprise",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Model_CreatedById",
                table: "Object_Model",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Model_LastModifiedById",
                table: "Object_Model",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Model_ModelLicenseId",
                table: "Object_Model",
                column: "ModelLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Object_Model_PricingUnitOfMeaureId",
                table: "Object_Model",
                column: "PricingUnitOfMeaureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Claim_Role_RoleId",
                table: "Role_Claim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Enterprise_EnterpriseIdEnterprise",
                table: "User",
                column: "EnterpriseIdEnterprise",
                principalTable: "Enterprise",
                principalColumn: "IdEnterprise",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Claim_User_UserId",
                table: "User_Claim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_External_Login_User_UserId",
                table: "User_External_Login",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Role_RoleId",
                table: "User_Role",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_User_UserId",
                table: "User_Role",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Token_User_UserId",
                table: "User_Token",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Claim_Role_RoleId",
                table: "Role_Claim");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Enterprise_EnterpriseIdEnterprise",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Claim_User_UserId",
                table: "User_Claim");

            migrationBuilder.DropForeignKey(
                name: "FK_User_External_Login_User_UserId",
                table: "User_External_Login");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Role_RoleId",
                table: "User_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_User_UserId",
                table: "User_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Token_User_UserId",
                table: "User_Token");

            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.DropTable(
                name: "Object_Model");

            migrationBuilder.DropTable(
                name: "Model_License");

            migrationBuilder.DropTable(
                name: "Unit_Of_Measure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Token",
                table: "User_Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Role",
                table: "User_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_External_Login",
                table: "User_External_Login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Claim",
                table: "User_Claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EnterpriseIdEnterprise",
                table: "User");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_Claim",
                table: "Role_Claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "EnterpriseIdEnterprise",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "User_Token",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "User_Role",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "User_External_Login",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "User_Claim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Role_Claim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_User_Role_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_External_Login_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Claim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Claim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
