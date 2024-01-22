using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infinity.ExamProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigAppUserExams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersExams",
                columns: table => new
                {
                    UsersExamsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExams", x => x.UsersExamsId);
                    table.ForeignKey(
                        name: "FK_UsersExams_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersExams_AppUserId",
                table: "UsersExams",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExams_ExamId",
                table: "UsersExams",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersExams");
        }
    }
}
