using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Web.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MontoPagado",
                table: "TicketPago",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vuelto",
                table: "TicketPago",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CentroMedico",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "TicketPago");

            migrationBuilder.DropColumn(
                name: "Vuelto",
                table: "TicketPago");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CentroMedico",
                nullable: true);
        }
    }
}
