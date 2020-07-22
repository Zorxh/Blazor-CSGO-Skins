using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGOSkinsWeb.Database.Migrations.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rarity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rarityname = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponCase",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    casename = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    casecollection = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    introduced = table.Column<DateTime>(type: "date", nullable: true),
                    idstring = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    imgsrc = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponCase", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponCollection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    collectionname = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    introduced = table.Column<DateTime>(type: "date", nullable: true),
                    idstring = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    imgsrc = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponCollection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weapname = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    category = table.Column<int>(nullable: true),
                    idstring = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    imgsrc = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.id);
                    table.ForeignKey(
                        name: "FK__Weapon__category__2C3393D0",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skin",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    skinname = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    weapon = table.Column<int>(nullable: true),
                    rarity = table.Column<int>(nullable: true),
                    weapcase = table.Column<int>(nullable: true),
                    weapcoll = table.Column<int>(nullable: true),
                    hasstattrak = table.Column<bool>(nullable: false),
                    hassouvenir = table.Column<bool>(nullable: false),
                    haspattern = table.Column<bool>(nullable: false),
                    wearstart = table.Column<double>(nullable: true),
                    wearend = table.Column<double>(nullable: true),
                    skindescription = table.Column<string>(unicode: false, nullable: true),
                    idstring = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    imgsrc = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skin", x => x.id);
                    table.ForeignKey(
                        name: "FK__Skin__rarity__5812160E",
                        column: x => x.rarity,
                        principalTable: "Rarity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Skin__weapcase__59063A47",
                        column: x => x.weapcase,
                        principalTable: "WeaponCase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Skin__weapcoll__59FA5E80",
                        column: x => x.weapcoll,
                        principalTable: "WeaponCollection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Skin__weapon__571DF1D5",
                        column: x => x.weapon,
                        principalTable: "Weapon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skin_rarity",
                table: "Skin",
                column: "rarity");

            migrationBuilder.CreateIndex(
                name: "IX_Skin_weapcase",
                table: "Skin",
                column: "weapcase");

            migrationBuilder.CreateIndex(
                name: "IX_Skin_weapcoll",
                table: "Skin",
                column: "weapcoll");

            migrationBuilder.CreateIndex(
                name: "IX_Skin_weapon",
                table: "Skin",
                column: "weapon");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_category",
                table: "Weapon",
                column: "category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skin");

            migrationBuilder.DropTable(
                name: "Rarity");

            migrationBuilder.DropTable(
                name: "WeaponCase");

            migrationBuilder.DropTable(
                name: "WeaponCollection");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
