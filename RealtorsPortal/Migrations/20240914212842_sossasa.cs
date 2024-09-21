using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorsPortal.Migrations
{
    /// <inheritdoc />
    public partial class sossasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "PrivateSeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "PrivateSeller");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Agents");
        }
    }
}
