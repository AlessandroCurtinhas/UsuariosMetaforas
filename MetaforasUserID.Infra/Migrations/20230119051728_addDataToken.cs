using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaforasUserID.Infra.Migrations
{
    public partial class addDataToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiracao",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpiracao",
                table: "Usuario");
        }
    }
}
