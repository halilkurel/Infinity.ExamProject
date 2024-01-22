using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infinity.ExamProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Exam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Exams_ExamId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ExamId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Categories");
        }
    }
}
