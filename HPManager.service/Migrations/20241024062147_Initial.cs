using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HPManager.service.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCitas",
                columns: table => new
                {
                    EstadoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCitas", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTratamientos",
                columns: table => new
                {
                    EstadoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTratamientos", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    RolId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<long>(type: "bigint", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolesUsuarios_RolId",
                        column: x => x.RolId,
                        principalTable: "RolesUsuarios",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    DocenteID = table.Column<long>(type: "bigint", nullable: false),
                    Asignatura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.DocenteID);
                    table.ForeignKey(
                        name: "FK_Docentes_Usuarios_DocenteID",
                        column: x => x.DocenteID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteID = table.Column<long>(type: "bigint", nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteID);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    ObservacionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.ObservacionID);
                    table.ForeignKey(
                        name: "FK_Observaciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PadresFamilia",
                columns: table => new
                {
                    PadreID = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadresFamilia", x => x.PadreID);
                    table.ForeignKey(
                        name: "FK_PadresFamilia_Usuarios_PadreID",
                        column: x => x.PadreID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Psicologos",
                columns: table => new
                {
                    PsicologoID = table.Column<long>(type: "bigint", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psicologos", x => x.PsicologoID);
                    table.ForeignKey(
                        name: "FK_Psicologos_Usuarios_PsicologoID",
                        column: x => x.PsicologoID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    TratamientoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.TratamientoID);
                    table.ForeignKey(
                        name: "FK_Tratamientos_EstadosTratamientos_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "EstadosTratamientos",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tratamientos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comportamiento",
                columns: table => new
                {
                    ComportamientoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocenteID = table.Column<long>(type: "bigint", nullable: false),
                    EstudianteID = table.Column<long>(type: "bigint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comportamiento", x => x.ComportamientoID);
                    table.ForeignKey(
                        name: "FK_Comportamiento_Docentes_DocenteID",
                        column: x => x.DocenteID,
                        principalTable: "Docentes",
                        principalColumn: "DocenteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comportamiento_Estudiantes_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: false),
                    PsicologoID = table.Column<long>(type: "bigint", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoID = table.Column<long>(type: "bigint", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_Citas_EstadosCitas_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "EstadosCitas",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Psicologos_PsicologoID",
                        column: x => x.PsicologoID,
                        principalTable: "Psicologos",
                        principalColumn: "PsicologoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recomendaciones",
                columns: table => new
                {
                    RecomendacionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocenteID = table.Column<long>(type: "bigint", nullable: false),
                    PsicologoID = table.Column<long>(type: "bigint", nullable: false),
                    EstudianteID = table.Column<long>(type: "bigint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recomendacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendaciones", x => x.RecomendacionID);
                    table.ForeignKey(
                        name: "FK_Recomendaciones_Docentes_DocenteID",
                        column: x => x.DocenteID,
                        principalTable: "Docentes",
                        principalColumn: "DocenteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recomendaciones_Estudiantes_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recomendaciones_Psicologos_PsicologoID",
                        column: x => x.PsicologoID,
                        principalTable: "Psicologos",
                        principalColumn: "PsicologoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsicologoID = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjetivoAlcanzado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AspectosAMejorar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Psicologos_PsicologoID",
                        column: x => x.PsicologoID,
                        principalTable: "Psicologos",
                        principalColumn: "PsicologoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoID",
                table: "Citas",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PsicologoID",
                table: "Citas",
                column: "PsicologoID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioID",
                table: "Citas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Comportamiento_DocenteID",
                table: "Comportamiento",
                column: "DocenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Comportamiento_EstudianteID",
                table: "Comportamiento",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_UsuarioID",
                table: "Observaciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_DocenteID",
                table: "Recomendaciones",
                column: "DocenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_EstudianteID",
                table: "Recomendaciones",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_PsicologoID",
                table: "Recomendaciones",
                column: "PsicologoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_PsicologoID",
                table: "Sesiones",
                column: "PsicologoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UsuarioID",
                table: "Sesiones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_EstadoID",
                table: "Tratamientos",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_UsuarioID",
                table: "Tratamientos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Comportamiento");

            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "PadresFamilia");

            migrationBuilder.DropTable(
                name: "Recomendaciones");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "EstadosCitas");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Psicologos");

            migrationBuilder.DropTable(
                name: "EstadosTratamientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");
        }
    }
}
