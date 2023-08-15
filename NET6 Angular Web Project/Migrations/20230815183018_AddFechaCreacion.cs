using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET6_Angular_Web_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FechaCreacion",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Users");
        }
    }
}
