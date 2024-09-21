﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorsPortal.Migrations
{
    /// <inheritdoc />
    public partial class chen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactUs");
        }
    }
}
