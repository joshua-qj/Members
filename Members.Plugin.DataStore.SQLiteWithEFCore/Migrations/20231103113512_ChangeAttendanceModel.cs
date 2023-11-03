using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Members.Plugin.DataStore.SQLiteWithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAttendanceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "AttendanceRecords",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "AttendanceRecords");
        }
    }
}
