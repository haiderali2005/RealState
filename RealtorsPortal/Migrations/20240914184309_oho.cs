using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorsPortal.Migrations
{
    /// <inheritdoc />
    public partial class oho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Agents_Id",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrivateSellerId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrivateSeller",
                columns: table => new
                {
                    PrivateSellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSeller", x => x.PrivateSellerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PrivateSellerId",
                table: "Properties",
                column: "PrivateSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Agents_Id",
                table: "Properties",
                column: "Id",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PrivateSeller_PrivateSellerId",
                table: "Properties",
                column: "PrivateSellerId",
                principalTable: "PrivateSeller",
                principalColumn: "PrivateSellerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Agents_Id",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PrivateSeller_PrivateSellerId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PrivateSeller");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PrivateSellerId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PrivateSellerId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Agents_Id",
                table: "Properties",
                column: "Id",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
