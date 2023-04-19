using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class Added_Book_Categories_in_BookTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoriesId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookCategoriesId",
                table: "Book",
                column: "BookCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCategories_BookCategoriesId",
                table: "Book",
                column: "BookCategoriesId",
                principalTable: "BookCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCategories_BookCategoriesId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookCategoriesId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookCategoriesId",
                table: "Book");
        }
    }
}
