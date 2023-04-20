using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class RemoveDepartmentFk_in_BorrowTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Department_DepartmentId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_DepartmentId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Borrows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_DepartmentId",
                table: "Borrows",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Department_DepartmentId",
                table: "Borrows",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
