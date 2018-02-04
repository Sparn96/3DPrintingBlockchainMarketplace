using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _3DPrintingBlockchainMarket.Data.Migrations
{
    public partial class morestudtodaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ObjectModelId",
                table: "Consumable_License",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumableLicenseId",
                table: "Authorization_Token",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_License_ObjectModelId",
                table: "Consumable_License",
                column: "ObjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_Token_ConsumableLicenseId",
                table: "Authorization_Token",
                column: "ConsumableLicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorization_Token_Consumable_License_ConsumableLicenseId",
                table: "Authorization_Token",
                column: "ConsumableLicenseId",
                principalTable: "Consumable_License",
                principalColumn: "IdConsumableLicense",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_License_Object_Model_ObjectModelId",
                table: "Consumable_License",
                column: "ObjectModelId",
                principalTable: "Object_Model",
                principalColumn: "IdObjectModel",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorization_Token_Consumable_License_ConsumableLicenseId",
                table: "Authorization_Token");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_License_Object_Model_ObjectModelId",
                table: "Consumable_License");

            migrationBuilder.DropIndex(
                name: "IX_Consumable_License_ObjectModelId",
                table: "Consumable_License");

            migrationBuilder.DropIndex(
                name: "IX_Authorization_Token_ConsumableLicenseId",
                table: "Authorization_Token");

            migrationBuilder.DropColumn(
                name: "ObjectModelId",
                table: "Consumable_License");

            migrationBuilder.DropColumn(
                name: "ConsumableLicenseId",
                table: "Authorization_Token");
        }
    }
}
