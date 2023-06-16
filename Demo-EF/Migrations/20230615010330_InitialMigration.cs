using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Filter",
            table: "Khoa",
            nullable: true,
            computedColumnSql: "LOWER([MaKhoa] + [TenKhoa] + [SDT])",
            stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
