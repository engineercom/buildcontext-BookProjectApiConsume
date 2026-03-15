using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Jane Austen", 180.0, "Gurur ve ÖnYargı" },
                    { 2, "Jack London", 125.0, "Martin Eden" },
                    { 3, "Jack London", 45.0, "Beyaz Diş" },
                    { 4, "Daniel Defoe", 330.0, "Kaptan Singleton" },
                    { 5, "William Golding", 384.0, "Akrep Kral" },
                    { 6, "Graham Greene", 560.0, "İstanbul Treni" },
                    { 7, "William Shakespeare", 300.0, "Macbeth" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
