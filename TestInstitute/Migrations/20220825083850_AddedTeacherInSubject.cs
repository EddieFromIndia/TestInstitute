#nullable disable

namespace TestInstitute.Migrations;

public partial class AddedTeacherInSubject : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Language",
            table: "Subjects");

        migrationBuilder.AddColumn<int>(
            name: "TeacherId",
            table: "Subjects",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_Subjects_TeacherId",
            table: "Subjects",
            column: "TeacherId");

        migrationBuilder.AddForeignKey(
            name: "FK_Subjects_Teachers_TeacherId",
            table: "Subjects",
            column: "TeacherId",
            principalTable: "Teachers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Subjects_Teachers_TeacherId",
            table: "Subjects");

        migrationBuilder.DropIndex(
            name: "IX_Subjects_TeacherId",
            table: "Subjects");

        migrationBuilder.DropColumn(
            name: "TeacherId",
            table: "Subjects");

        migrationBuilder.AddColumn<string>(
            name: "Language",
            table: "Subjects",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }
}
