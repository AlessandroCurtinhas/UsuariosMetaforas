using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaforasUserID.Infra.Migrations
{
    public partial class addTokenRecovery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TokenRecovery",
                table: "Usuario",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenRecovery",
                table: "Usuario");

        }
    }
}
