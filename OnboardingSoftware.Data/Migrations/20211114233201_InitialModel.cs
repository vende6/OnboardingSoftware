using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSoftware.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interesi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iskustvo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnaPozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipUgovora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokacijaPozicije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisPozicije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JeTrenutnoZaposlen = table.Column<bool>(type: "bit", nullable: false),
                    Dokument = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iskustvo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sektor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obrazovanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fakultet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smjer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrazovanje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trajanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojPitanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsvojeniProcenat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AplikantInteres",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    InteresiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantInteres", x => new { x.AplikantiID, x.InteresiID });
                    table.ForeignKey(
                        name: "FK_AplikantInteres_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantInteres_Interesi_InteresiID",
                        column: x => x.InteresiID,
                        principalTable: "Interesi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplikantIskustvo",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    IskustvoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantIskustvo", x => new { x.AplikantiID, x.IskustvoID });
                    table.ForeignKey(
                        name: "FK_AplikantIskustvo_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantIskustvo_Iskustvo_IskustvoID",
                        column: x => x.IskustvoID,
                        principalTable: "Iskustvo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplikantObrazovanje",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    ObrazovanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantObrazovanje", x => new { x.AplikantiID, x.ObrazovanjeID });
                    table.ForeignKey(
                        name: "FK_AplikantObrazovanje_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantObrazovanje_Obrazovanje_ObrazovanjeID",
                        column: x => x.ObrazovanjeID,
                        principalTable: "Obrazovanje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplikantTest",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    TestoviID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantTest", x => new { x.AplikantiID, x.TestoviID });
                    table.ForeignKey(
                        name: "FK_AplikantTest_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantTest_Test_TestoviID",
                        column: x => x.TestoviID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokacijaID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posao_Lokacija_LokacijaID",
                        column: x => x.LokacijaID,
                        principalTable: "Lokacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posao_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplikantPosao",
                columns: table => new
                {
                    AplikantiID = table.Column<int>(type: "int", nullable: false),
                    PosloviID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantPosao", x => new { x.AplikantiID, x.PosloviID });
                    table.ForeignKey(
                        name: "FK_AplikantPosao_Aplikanti_AplikantiID",
                        column: x => x.AplikantiID,
                        principalTable: "Aplikanti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantPosao_Posao_PosloviID",
                        column: x => x.PosloviID,
                        principalTable: "Posao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikantInteres_InteresiID",
                table: "AplikantInteres",
                column: "InteresiID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikantIskustvo_IskustvoID",
                table: "AplikantIskustvo",
                column: "IskustvoID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikantObrazovanje_ObrazovanjeID",
                table: "AplikantObrazovanje",
                column: "ObrazovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikantPosao_PosloviID",
                table: "AplikantPosao",
                column: "PosloviID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikantTest_TestoviID",
                table: "AplikantTest",
                column: "TestoviID");

            migrationBuilder.CreateIndex(
                name: "IX_Posao_LokacijaID",
                table: "Posao",
                column: "LokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Posao_TestID",
                table: "Posao",
                column: "TestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikantInteres");

            migrationBuilder.DropTable(
                name: "AplikantIskustvo");

            migrationBuilder.DropTable(
                name: "AplikantObrazovanje");

            migrationBuilder.DropTable(
                name: "AplikantPosao");

            migrationBuilder.DropTable(
                name: "AplikantTest");

            migrationBuilder.DropTable(
                name: "Interesi");

            migrationBuilder.DropTable(
                name: "Iskustvo");

            migrationBuilder.DropTable(
                name: "Obrazovanje");

            migrationBuilder.DropTable(
                name: "Posao");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
