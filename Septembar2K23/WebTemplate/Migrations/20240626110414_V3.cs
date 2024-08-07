using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SastojakZarada");

            migrationBuilder.AddColumn<int>(
                name: "ZaradeID",
                table: "Sastojci",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_ZaradeID",
                table: "Sastojci",
                column: "ZaradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sastojci_Zarade_ZaradeID",
                table: "Sastojci",
                column: "ZaradeID",
                principalTable: "Zarade",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sastojci_Zarade_ZaradeID",
                table: "Sastojci");

            migrationBuilder.DropIndex(
                name: "IX_Sastojci_ZaradeID",
                table: "Sastojci");

            migrationBuilder.DropColumn(
                name: "ZaradeID",
                table: "Sastojci");

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
        }
    }
}
