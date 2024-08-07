using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Licna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ture",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Znamenitosti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znamenitosti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikTura",
                columns: table => new
                {
                    KorisniciID = table.Column<int>(type: "int", nullable: false),
                    TureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikTura", x => new { x.KorisniciID, x.TureID });
                    table.ForeignKey(
                        name: "FK_KorisnikTura_Korisnici_KorisniciID",
                        column: x => x.KorisniciID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikTura_Ture_TureID",
                        column: x => x.TureID,
                        principalTable: "Ture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TuraZnamenitost",
                columns: table => new
                {
                    TureID = table.Column<int>(type: "int", nullable: false),
                    ZnamenitostiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuraZnamenitost", x => new { x.TureID, x.ZnamenitostiID });
                    table.ForeignKey(
                        name: "FK_TuraZnamenitost_Ture_TureID",
                        column: x => x.TureID,
                        principalTable: "Ture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuraZnamenitost_Znamenitosti_ZnamenitostiID",
                        column: x => x.ZnamenitostiID,
                        principalTable: "Znamenitosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTura_TureID",
                table: "KorisnikTura",
                column: "TureID");

            migrationBuilder.CreateIndex(
                name: "IX_TuraZnamenitost_ZnamenitostiID",
                table: "TuraZnamenitost",
                column: "ZnamenitostiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikTura");

            migrationBuilder.DropTable(
                name: "TuraZnamenitost");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Ture");

            migrationBuilder.DropTable(
                name: "Znamenitosti");
        }
    }
}
