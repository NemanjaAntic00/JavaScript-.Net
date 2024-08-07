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
                name: "Prodavnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zarade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesta = table.Column<int>(type: "int", nullable: false),
                    Pazar = table.Column<int>(type: "int", nullable: false),
                    ProdavnicaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zarade", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zarade_Prodavnice_ProdavnicaID",
                        column: x => x.ProdavnicaID,
                        principalTable: "Prodavnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SastojakZarada",
                columns: table => new
                {
                    SastojciID = table.Column<int>(type: "int", nullable: false),
                    ZaradeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastojakZarada", x => new { x.SastojciID, x.ZaradeID });
                    table.ForeignKey(
                        name: "FK_SastojakZarada_Sastojci_SastojciID",
                        column: x => x.SastojciID,
                        principalTable: "Sastojci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SastojakZarada_Zarade_ZaradeID",
                        column: x => x.ZaradeID,
                        principalTable: "Zarade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SastojakZarada_ZaradeID",
                table: "SastojakZarada",
                column: "ZaradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zarade_ProdavnicaID",
                table: "Zarade",
                column: "ProdavnicaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SastojakZarada");

            migrationBuilder.DropTable(
                name: "Sastojci");

            migrationBuilder.DropTable(
                name: "Zarade");

            migrationBuilder.DropTable(
                name: "Prodavnice");
        }
    }
}
