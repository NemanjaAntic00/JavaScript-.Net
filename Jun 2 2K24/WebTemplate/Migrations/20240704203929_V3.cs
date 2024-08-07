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
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Korisnici_KorisnikID",
                table: "KorisnikTura");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTura_Ture_TuraID",
                table: "KorisnikTura");

            migrationBuilder.DropForeignKey(
                name: "FK_ZnamenitostTura_Ture_Turaid",
                table: "ZnamenitostTura");

            migrationBuilder.DropForeignKey(
                name: "FK_ZnamenitostTura_Znamenitosti_ZnamenitostID",
                table: "ZnamenitostTura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZnamenitostTura",
                table: "ZnamenitostTura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikTura",
                table: "KorisnikTura");

            migrationBuilder.RenameTable(
                name: "ZnamenitostTura",
                newName: "ZnamenitostTure");

            migrationBuilder.RenameTable(
                name: "KorisnikTura",
                newName: "KorisnikTure");

            migrationBuilder.RenameIndex(
                name: "IX_ZnamenitostTura_Turaid",
                table: "ZnamenitostTure",
                newName: "IX_ZnamenitostTure_Turaid");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikTura_TuraID",
                table: "KorisnikTure",
                newName: "IX_KorisnikTure_TuraID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZnamenitostTure",
                table: "ZnamenitostTure",
                columns: new[] { "ZnamenitostID", "Turaid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikTure",
                table: "KorisnikTure",
                columns: new[] { "KorisnikID", "TuraID" });

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTure_Korisnici_KorisnikID",
                table: "KorisnikTure",
                column: "KorisnikID",
                principalTable: "Korisnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikTure_Ture_TuraID",
                table: "KorisnikTure",
                column: "TuraID",
                principalTable: "Ture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZnamenitostTure_Ture_Turaid",
                table: "ZnamenitostTure",
                column: "Turaid",
                principalTable: "Ture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZnamenitostTure_Znamenitosti_ZnamenitostID",
                table: "ZnamenitostTure",
                column: "ZnamenitostID",
                principalTable: "Znamenitosti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTure_Korisnici_KorisnikID",
                table: "KorisnikTure");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikTure_Ture_TuraID",
                table: "KorisnikTure");

            migrationBuilder.DropForeignKey(
                name: "FK_ZnamenitostTure_Ture_Turaid",
                table: "ZnamenitostTure");

            migrationBuilder.DropForeignKey(
                name: "FK_ZnamenitostTure_Znamenitosti_ZnamenitostID",
                table: "ZnamenitostTure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZnamenitostTure",
                table: "ZnamenitostTure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikTure",
                table: "KorisnikTure");

            migrationBuilder.RenameTable(
                name: "ZnamenitostTure",
                newName: "ZnamenitostTura");

            migrationBuilder.RenameTable(
                name: "KorisnikTure",
                newName: "KorisnikTura");

            migrationBuilder.RenameIndex(
                name: "IX_ZnamenitostTure_Turaid",
                table: "ZnamenitostTura",
                newName: "IX_ZnamenitostTura_Turaid");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikTure_TuraID",
                table: "KorisnikTura",
                newName: "IX_KorisnikTura_TuraID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZnamenitostTura",
                table: "ZnamenitostTura",
                columns: new[] { "ZnamenitostID", "Turaid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikTura",
                table: "KorisnikTura",
                columns: new[] { "KorisnikID", "TuraID" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ZnamenitostTura_Ture_Turaid",
                table: "ZnamenitostTura",
                column: "Turaid",
                principalTable: "Ture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZnamenitostTura_Znamenitosti_ZnamenitostID",
                table: "ZnamenitostTura",
                column: "ZnamenitostID",
                principalTable: "Znamenitosti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
