using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infinity.ExamProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExamUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Exams_ExamId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ExamId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CategoryId",
                table: "Exams",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Categories_CategoryId",
                table: "Exams",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Categories_CategoryId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CategoryId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ExamId",
                table: "Categories",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Exams_ExamId",
                table: "Categories",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");
        }
    }
}
