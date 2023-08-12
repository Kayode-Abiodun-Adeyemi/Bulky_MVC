using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Chesterfield", "City Centre Limited", "+4477777777777", null, "South York Shire", "6, Ashgate Road" },
                    { 2, "Central London", "London Bookshop Limited", "+4477777777788", null, "London", "30, Derbyshire Road" },
                    { 3, "Nottingham", "Concordant Express Limited", "+4477777777799", null, "Scotland", "24, Nottingham Street" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
