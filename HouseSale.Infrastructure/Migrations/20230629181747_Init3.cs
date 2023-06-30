using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseSale.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSituations_Houses_HouseId",
                table: "HomeSituations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocatedNearbies_Houses_HouseId",
                table: "LocatedNearbies");

            migrationBuilder.DropForeignKey(
                name: "FK_ThereIsInHouses_Houses_HouseId",
                table: "ThereIsInHouses");

            migrationBuilder.DropIndex(
                name: "IX_ThereIsInHouses_HouseId",
                table: "ThereIsInHouses");

            migrationBuilder.DropIndex(
                name: "IX_LocatedNearbies_HouseId",
                table: "LocatedNearbies");

            migrationBuilder.DropIndex(
                name: "IX_HomeSituations_HouseId",
                table: "HomeSituations");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "ThereIsInHouses");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "LocatedNearbies");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "HomeSituations");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeSituationId",
                table: "Houses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocatedNearbyId",
                table: "Houses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThereIsInHouseId",
                table: "Houses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HomeSituationId",
                table: "Houses",
                column: "HomeSituationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_LocatedNearbyId",
                table: "Houses",
                column: "LocatedNearbyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_ThereIsInHouseId",
                table: "Houses",
                column: "ThereIsInHouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_HomeSituations_HomeSituationId",
                table: "Houses",
                column: "HomeSituationId",
                principalTable: "HomeSituations",
                principalColumn: "HomeSituationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_LocatedNearbies_LocatedNearbyId",
                table: "Houses",
                column: "LocatedNearbyId",
                principalTable: "LocatedNearbies",
                principalColumn: "LocatedNearbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ThereIsInHouses_ThereIsInHouseId",
                table: "Houses",
                column: "ThereIsInHouseId",
                principalTable: "ThereIsInHouses",
                principalColumn: "ThereIsInHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_HomeSituations_HomeSituationId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_LocatedNearbies_LocatedNearbyId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ThereIsInHouses_ThereIsInHouseId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_HomeSituationId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_LocatedNearbyId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_ThereIsInHouseId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HomeSituationId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "LocatedNearbyId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "ThereIsInHouseId",
                table: "Houses");

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "ThereIsInHouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "LocatedNearbies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "HomeSituations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ThereIsInHouses_HouseId",
                table: "ThereIsInHouses",
                column: "HouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocatedNearbies_HouseId",
                table: "LocatedNearbies",
                column: "HouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeSituations_HouseId",
                table: "HomeSituations",
                column: "HouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSituations_Houses_HouseId",
                table: "HomeSituations",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocatedNearbies_Houses_HouseId",
                table: "LocatedNearbies",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThereIsInHouses_Houses_HouseId",
                table: "ThereIsInHouses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
