﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePointOfInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PointOfInterest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PointOfInterest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
