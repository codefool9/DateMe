using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateMe.Migrations
{
    /// <inheritdoc />
    public partial class AddMajorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "MajorID",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajorName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorID);
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorID", "MajorName" },
                values: new object[,]
                {
                    { 1, "Information Systems" },
                    { 2, "Computer Science" },
                    { 3, "Magic" },
                    { 4, "Accounting" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_MajorID",
                table: "Applications",
                column: "MajorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Majors_MajorID",
                table: "Applications",
                column: "MajorID",
                principalTable: "Majors",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Majors_MajorID",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Applications_MajorID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "MajorID",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
