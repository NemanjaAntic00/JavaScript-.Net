using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krarte_Projekcije_ProjekcijaID",
                table: "Krarte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Krarte",
                table: "Krarte");

            migrationBuilder.RenameTable(
                name: "Krarte",
                newName: "Karte");

            migrationBuilder.RenameIndex(
                name: "IX_Krarte_ProjekcijaID",
                table: "Karte",
                newName: "IX_Karte_ProjekcijaID");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Karte",
                table: "Karte",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karte_Projekcije_ProjekcijaID",
                table: "Karte",
                column: "ProjekcijaID",
                principalTable: "Projekcije",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karte_Projekcije_ProjekcijaID",
                table: "Karte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Karte",
                table: "Karte");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "Karte",
                newName: "Krarte");

            migrationBuilder.RenameIndex(
                name: "IX_Karte_ProjekcijaID",
                table: "Krarte",
                newName: "IX_Krarte_ProjekcijaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Krarte",
                table: "Krarte",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Krarte_Projekcije_ProjekcijaID",
                table: "Krarte",
                column: "ProjekcijaID",
                principalTable: "Projekcije",
                principalColumn: "ID");
        }
    }
}
