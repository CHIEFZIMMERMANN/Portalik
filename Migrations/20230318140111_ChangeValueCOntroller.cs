using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValueCOntroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "TemperatureC",
                table: "Values");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Values",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Values",
                newName: "Summary");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Values",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TemperatureC",
                table: "Values",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
