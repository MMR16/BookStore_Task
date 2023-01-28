using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rented = table.Column<bool>(type: "bit", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookBorrowers",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookBorrowers", x => new { x.BookId, x.BorrowerId });
                    table.ForeignKey(
                        name: "FK_bookBorrowers_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookBorrowers_borrowers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "borrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Available", "Code", "Rented", "Title" },
                values: new object[,]
                {
                    { 1, "Microsoft", false, "as123", true, "dotnet" },
                    { 2, "Microsoft", false, "as456", true, "dotnet" },
                    { 3, "Microsoft", false, "as789", true, "dotnet" },
                    { 4, "Google", false, "we1111", true, "Angular" },
                    { 5, "Google", false, "we9874", true, "Angular" },
                    { 6, "FaceBook", false, "tr2515", true, "React" },
                    { 7, "Sun Microsystems", false, "bv4564", true, "Java" },
                    { 8, "Microsoft", true, "gf444", false, "dotnet" },
                    { 9, "Microsoft", true, "trt77", false, "dotnet" },
                    { 10, "Microsoft", true, "gf5596", false, "dotnet" },
                    { 11, "Google", true, "tr9963", false, "Angular" },
                    { 12, "Google", true, "uy5512", false, "Angular" }
                });

            migrationBuilder.InsertData(
                table: "borrowers",
                columns: new[] { "Id", "Name", "NationalId" },
                values: new object[,]
                {
                    { 1, "Mostafa", 120365 },
                    { 2, "Ali", 787454 },
                    { 3, "Ahmed", 477449 },
                    { 4, "Alaa", 8854471 }
                });

            migrationBuilder.InsertData(
                table: "bookBorrowers",
                columns: new[] { "BookId", "BorrowerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 4 },
                    { 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookBorrowers_BorrowerId",
                table: "bookBorrowers",
                column: "BorrowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookBorrowers");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "borrowers");
        }
    }
}
