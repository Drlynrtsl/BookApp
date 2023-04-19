using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class fixeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Students_StudentId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Book_StudentId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Borrows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Borrows",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Book_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Students_StudentId",
                table: "Borrows",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
