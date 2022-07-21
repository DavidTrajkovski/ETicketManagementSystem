using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketEShop.Repository.Migrations
{
    public partial class DatePremiere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePremiere",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DatePremiere",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
