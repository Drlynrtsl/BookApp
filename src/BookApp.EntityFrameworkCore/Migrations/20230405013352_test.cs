using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Book_BookIdId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Book_BookNameId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_BookIdId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "BookIdId",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Borrows",
                newName: "ExpectedReturnDate");

            migrationBuilder.RenameColumn(
                name: "IsBorrow",
                table: "Borrows",
                newName: "IsBorrowed");

            migrationBuilder.RenameColumn(
                name: "BookNameId",
                table: "Borrows",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_BookNameId",
                table: "Borrows",
                newName: "IX_Borrows_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "IsBorrowed",
                table: "Borrows",
                newName: "IsBorrow");

            migrationBuilder.RenameColumn(
                name: "ExpectedReturnDate",
                table: "Borrows",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Borrows",
                newName: "BookNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                newName: "IX_Borrows_BookNameId");

            migrationBuilder.AddColumn<int>(
                name: "BookIdId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookIdId",
                table: "Borrows",
                column: "BookIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Book_BookIdId",
                table: "Borrows",
                column: "BookIdId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Book_BookNameId",
                table: "Borrows",
                column: "BookNameId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
