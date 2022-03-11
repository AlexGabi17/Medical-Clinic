using Microsoft.EntityFrameworkCore.Migrations;

namespace API.DAL.Migrations
{
    public partial class AddedDiagnosticTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Office_OfficeId",
                table: "Doctors",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Office_OfficeId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Doctors");
        }
    }
}
