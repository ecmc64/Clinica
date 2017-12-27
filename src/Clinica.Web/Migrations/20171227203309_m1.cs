using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinica.Web.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroMedico",
                columns: table => new
                {
                    CentroMedicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Telefonos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroMedico", x => x.CentroMedicoId);
                });

            migrationBuilder.CreateTable(
                name: "CitaEstado",
                columns: table => new
                {
                    CitaEstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaEstado", x => x.CitaEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "CitaTipo",
                columns: table => new
                {
                    CitaTipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaTipo", x => x.CitaTipoId);
                });

            migrationBuilder.CreateTable(
                name: "PacienteCategoria",
                columns: table => new
                {
                    PacienteCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteCategoria", x => x.PacienteCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalHorario",
                columns: table => new
                {
                    ProfesionalHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Horario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalHorario", x => x.ProfesionalHorarioId);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalTipo",
                columns: table => new
                {
                    ProfesionalTipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalTipo", x => x.ProfesionalTipoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApellidoMaterno = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    PacienteCategoriaId = table.Column<int>(nullable: false),
                    Telefonos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_PacienteCategoria_PacienteCategoriaId",
                        column: x => x.PacienteCategoriaId,
                        principalTable: "PacienteCategoria",
                        principalColumn: "PacienteCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    TarifaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CentroMedicoId = table.Column<int>(nullable: false),
                    CitaTipoId = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    PacienteCategoriaId = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.TarifaId);
                    table.ForeignKey(
                        name: "FK_Tarifa_CentroMedico_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedico",
                        principalColumn: "CentroMedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarifa_CitaTipo_CitaTipoId",
                        column: x => x.CitaTipoId,
                        principalTable: "CitaTipo",
                        principalColumn: "CitaTipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarifa_PacienteCategoria_PacienteCategoriaId",
                        column: x => x.PacienteCategoriaId,
                        principalTable: "PacienteCategoria",
                        principalColumn: "PacienteCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesional",
                columns: table => new
                {
                    ProfesionalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    ProfesionalTipoId = table.Column<int>(nullable: false),
                    Telefonos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesional", x => x.ProfesionalId);
                    table.ForeignKey(
                        name: "FK_Profesional_ProfesionalTipo_ProfesionalTipoId",
                        column: x => x.ProfesionalTipoId,
                        principalTable: "ProfesionalTipo",
                        principalColumn: "ProfesionalTipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    CitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CentroMedicoId = table.Column<int>(nullable: false),
                    CitaEstadoId = table.Column<int>(nullable: false),
                    CitaTipoId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaRegistra = table.Column<DateTime>(nullable: false),
                    Fin = table.Column<DateTime>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    ProfesionalId = table.Column<int>(nullable: false),
                    UsuarioRegistra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_Cita_CentroMedico_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedico",
                        principalColumn: "CentroMedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_CitaEstado_CitaEstadoId",
                        column: x => x.CitaEstadoId,
                        principalTable: "CitaEstado",
                        principalColumn: "CitaEstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_CitaTipo_CitaTipoId",
                        column: x => x.CitaTipoId,
                        principalTable: "CitaTipo",
                        principalColumn: "CitaTipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Profesional_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesional",
                        principalColumn: "ProfesionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalCentroMedico",
                columns: table => new
                {
                    ProfesionalCentroMedicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CentroMedicoId = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: true),
                    ProfesionalHorarioId = table.Column<int>(nullable: false),
                    ProfesionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalCentroMedico", x => x.ProfesionalCentroMedicoId);
                    table.ForeignKey(
                        name: "FK_ProfesionalCentroMedico_CentroMedico_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedico",
                        principalColumn: "CentroMedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesionalCentroMedico_ProfesionalHorario_ProfesionalHorarioId",
                        column: x => x.ProfesionalHorarioId,
                        principalTable: "ProfesionalHorario",
                        principalColumn: "ProfesionalHorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesionalCentroMedico_Profesional_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesional",
                        principalColumn: "ProfesionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPago",
                columns: table => new
                {
                    TicketPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CitaId = table.Column<int>(nullable: false),
                    NumeroComprobante = table.Column<string>(nullable: true),
                    Pagado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPago", x => x.TicketPagoId);
                    table.ForeignKey(
                        name: "FK_TicketPago_Cita_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Cita",
                        principalColumn: "CitaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_CentroMedicoId",
                table: "Cita",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_CitaEstadoId",
                table: "Cita",
                column: "CitaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_CitaTipoId",
                table: "Cita",
                column: "CitaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ProfesionalId",
                table: "Cita",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PacienteCategoriaId",
                table: "Paciente",
                column: "PacienteCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_ProfesionalTipoId",
                table: "Profesional",
                column: "ProfesionalTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalCentroMedico_CentroMedicoId",
                table: "ProfesionalCentroMedico",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalCentroMedico_ProfesionalHorarioId",
                table: "ProfesionalCentroMedico",
                column: "ProfesionalHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalCentroMedico_ProfesionalId",
                table: "ProfesionalCentroMedico",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifa_CentroMedicoId",
                table: "Tarifa",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifa_CitaTipoId",
                table: "Tarifa",
                column: "CitaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifa_PacienteCategoriaId",
                table: "Tarifa",
                column: "PacienteCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPago_CitaId",
                table: "TicketPago",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesionalCentroMedico");

            migrationBuilder.DropTable(
                name: "Tarifa");

            migrationBuilder.DropTable(
                name: "TicketPago");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProfesionalHorario");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CentroMedico");

            migrationBuilder.DropTable(
                name: "CitaEstado");

            migrationBuilder.DropTable(
                name: "CitaTipo");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Profesional");

            migrationBuilder.DropTable(
                name: "PacienteCategoria");

            migrationBuilder.DropTable(
                name: "ProfesionalTipo");
        }
    }
}
