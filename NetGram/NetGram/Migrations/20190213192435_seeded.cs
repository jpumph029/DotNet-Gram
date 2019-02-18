using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class seeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Gram",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 1,
                column: "Title",
                value: "LOLOLOL");

            migrationBuilder.UpdateData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 2,
                column: "Title",
                value: "This dog!");

            migrationBuilder.UpdateData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 3,
                column: "Title",
                value: "This is Seattle");

            migrationBuilder.UpdateData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 4,
                column: "Title",
                value: ":)");

            migrationBuilder.UpdateData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 5,
                column: "Title",
                value: "I love this pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Gram");
        }
    }
}
