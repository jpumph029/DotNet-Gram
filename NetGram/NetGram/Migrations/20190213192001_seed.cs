using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gram",
                columns: new[] { "ID", "Description", "Name", "URL" },
                values: new object[,]
                {
                    { 1, null, "Bill", ".png" },
                    { 2, null, "Sam", ".png" },
                    { 3, null, "Joe", ".png" },
                    { 4, null, "Kat", ".png" },
                    { 5, null, "Mat", ".png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gram",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
