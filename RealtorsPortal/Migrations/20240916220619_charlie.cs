using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorsPortal.Migrations
{
    /// <inheritdoc />
    public partial class charlie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PrivateSeller_PrivateSellerId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateSeller",
                table: "PrivateSeller");

            migrationBuilder.RenameTable(
                name: "PrivateSeller",
                newName: "PrivateSellers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateSellers",
                table: "PrivateSellers",
                column: "PrivateSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PrivateSellers_PrivateSellerId",
                table: "Properties",
                column: "PrivateSellerId",
                principalTable: "PrivateSellers",
                principalColumn: "PrivateSellerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PrivateSellers_PrivateSellerId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateSellers",
                table: "PrivateSellers");

            migrationBuilder.RenameTable(
                name: "PrivateSellers",
                newName: "PrivateSeller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateSeller",
                table: "PrivateSeller",
                column: "PrivateSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PrivateSeller_PrivateSellerId",
                table: "Properties",
                column: "PrivateSellerId",
                principalTable: "PrivateSeller",
                principalColumn: "PrivateSellerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
