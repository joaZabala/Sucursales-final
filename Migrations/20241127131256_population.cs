using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace repasoFinal2daMesa.Migrations
{
    /// <inheritdoc />
    public partial class population : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configuraciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuraciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sucursales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCiudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProvincia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sucursales_provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sucursales_tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "configuraciones",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440006"), "padding-top", "50px" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440007"), "padding-left", "100px" }
                });

            migrationBuilder.InsertData(
                table: "provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440001"), "Córdoba" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440002"), "Buenos Aires" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440003"), "Salta" }
                });

            migrationBuilder.InsertData(
                table: "tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440004"), "Pequeña" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440005"), "Grande" }
                });

            migrationBuilder.InsertData(
                table: "sucursales",
                columns: new[] { "Id", "ApellidoTitular", "FechaAlta", "IdCiudad", "IdProvincia", "IdTipo", "Nombre", "NombreTitular", "Telefono" },
                values: new object[,]
                {
                    { new Guid("0a900986-a6b9-4622-bbb2-b46078b01baf"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7911), "BA001", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal Córdoba Oeste", "Joaquin", "11-45678228" },
                    { new Guid("43588888-df4b-4a51-9dc7-4b81aa0cc6c6"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7920), "SA1", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal salta Oeste", "Joaquin", "88-45673388" },
                    { new Guid("4b9530b2-30e3-4acf-91b8-5ec2efcc24fd"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7901), "CB661", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal Córdoba sur", "Joaquin", "0351-45678888" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440009"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7864), "CBA5551", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal Córdoba norte", "Joaquin", "0351-45678888" },
                    { new Guid("5c9a4b0f-6554-40ff-a906-35b54a1daedc"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7907), "CB221", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal Córdoba Oeste", "Joaquin", "0351-45678888" },
                    { new Guid("c64c4900-901b-4241-99b4-ae2274235f7b"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 761, DateTimeKind.Local).AddTicks(6570), "CBA001", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("550e8400-e29b-41d4-a716-446655440004"), "Sucursal Córdoba Centro", "María", "0351-4567890" },
                    { new Guid("f9ce11fd-e42f-4bb1-a1bb-6921e0349950"), "Gómez", new DateTime(2024, 11, 27, 10, 12, 55, 764, DateTimeKind.Local).AddTicks(7916), "SA777", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("550e8400-e29b-41d4-a716-446655440005"), "Sucursal salta Oeste", "Joaquin", "88-4567887448" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_sucursales_IdProvincia",
                table: "sucursales",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_sucursales_IdTipo",
                table: "sucursales",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuraciones");

            migrationBuilder.DropTable(
                name: "sucursales");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "tipos");
        }
    }
}
