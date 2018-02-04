using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _3DPrintingBlockchainMarket.Data.Migrations
{
    public partial class distractedbydemraps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorization_Token",
                columns: table => new
                {
                    IdAuthToken = table.Column<Guid>(nullable: false),
                    AuthUserId = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateExpires = table.Column<DateTime>(nullable: false),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModifiedById = table.Column<string>(nullable: true),
                    ObjectModeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorization_Token", x => x.IdAuthToken);
                    table.ForeignKey(
                        name: "FK_Authorization_Token_User_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authorization_Token_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authorization_Token_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authorization_Token_Object_Model_ObjectModeId",
                        column: x => x.ObjectModeId,
                        principalTable: "Object_Model",
                        principalColumn: "IdObjectModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumable_License",
                columns: table => new
                {
                    IdConsumableLicense = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateInactivted = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModifiedById = table.Column<string>(nullable: true),
                    ModelLicenseId = table.Column<Guid>(nullable: false),
                    NumberOfUses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumable_License", x => x.IdConsumableLicense);
                    table.ForeignKey(
                        name: "FK_Consumable_License_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_License_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_License_Model_License_ModelLicenseId",
                        column: x => x.ModelLicenseId,
                        principalTable: "Model_License",
                        principalColumn: "IdLicense",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_Token_AuthUserId",
                table: "Authorization_Token",
                column: "AuthUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_Token_CreatedById",
                table: "Authorization_Token",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_Token_LastModifiedById",
                table: "Authorization_Token",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_Token_ObjectModeId",
                table: "Authorization_Token",
                column: "ObjectModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_License_CreatedById",
                table: "Consumable_License",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_License_LastModifiedById",
                table: "Consumable_License",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_License_ModelLicenseId",
                table: "Consumable_License",
                column: "ModelLicenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorization_Token");

            migrationBuilder.DropTable(
                name: "Consumable_License");
        }
    }
}
