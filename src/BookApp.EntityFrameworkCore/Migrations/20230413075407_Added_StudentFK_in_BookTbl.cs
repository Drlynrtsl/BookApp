using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class Added_StudentFK_in_BookTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_StudentId",
                table: "Book",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Students_StudentId",
                table: "Book",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Students_StudentId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_StudentId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Book");
        }
    }
}
