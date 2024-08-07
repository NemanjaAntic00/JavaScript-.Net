using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Korisnici_KorisniciID",
                table: "KorisnikTura");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Ture_TureID",
                table: "KorisnikTura");

            migrationBuilder.DropTable(
                name: "TuraZnamenitost");

            migrationBuilder.RenameColumn(
                name: "TureID",
                table: "KorisnikTura",
                newName: "TuraID");

            migrationBuilder.RenameColumn(
                name: "KorisniciID",
                table: "KorisnikTura",
                newName: "KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikTura_TureID",
                table: "KorisnikTura",
                newName: "IX_KorisnikTura_TuraID");

            migrationBuilder.CreateTable(
                name: "ZnamenitostTura",
                columns: table => new
                {
                    ZnamenitostID = table.Column<int>(type: "int", nullable: false),
                    Turaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZnamenitostTura", x => new { x.ZnamenitostID, x.Turaid });
                    table.ForeignKey(
                        name: "FK_ZnamenitostTura_Ture_Turaid",
                        column: x => x.Turaid,
                        principalTable: "Ture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZnamenitostTura_Znamenitosti_ZnamenitostID",
                        column: x => x.ZnamenitostID,
                        principalTable: "Znamenitosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZnamenitostTura_Turaid",
                table: "ZnamenitostTura",
                column: "Turaid");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTura_Korisnici_KorisnikID",
                table: "KorisnikTura",
                column: "KorisnikID",
                principalTable: "Korisnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTura_Ture_TuraID",
                table: "KorisnikTura",
                column: "TuraID",
                principalTable: "Ture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Korisnici_KorisnikID",
                table: "KorisnikTura");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Ture_TuraID",
                table: "KorisnikTura");

            migrationBuilder.DropTable(
                name: "ZnamenitostTura");

            migrationBuilder.RenameColumn(
                name: "TuraID",
                table: "KorisnikTura",
                newName: "TureID");

            migrationBuilder.RenameColumn(
                name: "KorisnikID",
                table: "KorisnikTura",
                newName: "KorisniciID");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikTura_TuraID",
                table: "KorisnikTura",
                newName: "IX_KorisnikTura_TureID");

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
                name: "IX_TuraZnamenitost_ZnamenitostiID",
                table: "TuraZnamenitost",
                column: "ZnamenitostiID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTura_Korisnici_KorisniciID",
                table: "KorisnikTura",
                column: "KorisniciID",
                principalTable: "Korisnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTura_Ture_TureID",
                table: "KorisnikTura",
                column: "TureID",
                principalTable: "Ture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
