using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSoftware.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplikanti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    JeVerifikovan = table.Column<bool>(type: "bit", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusZaposlenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokacijaZaposlenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrenutnaPozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industrija = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplikanti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vjestine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjestine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AplikantVjestina",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    VjestineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantVjestina", x => new { x.AplikantiID, x.VjestineID });
                    table.ForeignKey(
                        name: "FK_AplikantVjestina_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantVjestina_Vjestine_VjestineID",
                        column: x => x.VjestineID,
                        principalTable: "Vjestine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikantVjestina_VjestineID",
                table: "AplikantVjestina",
                column: "VjestineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikantVjestina");

            migrationBuilder.DropTable(
                name: "Aplikanti");

            migrationBuilder.DropTable(
                name: "Vjestine");
        }
    }
}
