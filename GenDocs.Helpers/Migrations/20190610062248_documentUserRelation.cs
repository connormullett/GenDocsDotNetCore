using Microsoft.EntityFrameworkCore.Migrations;

namespace GenDocs.Helpers.Migrations
{
    public partial class documentUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerId",
                table: "Documents",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_OwnerId",
                table: "Documents",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_OwnerId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_OwnerId",
                table: "Documents");
        }
    }
}
