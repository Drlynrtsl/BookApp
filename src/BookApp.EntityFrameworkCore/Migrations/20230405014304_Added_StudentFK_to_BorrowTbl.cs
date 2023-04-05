using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class Added_StudentFK_to_BorrowTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_StudentId",
                table: "Borrows",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_StudentId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Borrows");
        }
    }
}
