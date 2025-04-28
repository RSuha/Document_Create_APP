﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateDocumentAPP_2.Migrations
{
    /// <inheritdoc />
    public partial class AddKategoriToProjeDiyagram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "ProjeDiyagramlari",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "ProjeDiyagramlari");
        }
    }
}
