using Microsoft.EntityFrameworkCore;
using repasoFinal2daMesa.Models;
using System.Reflection.Emit;

namespace repasoFinal2daMesa.data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }


        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Tipos> Tipos { get; set; }

        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Configuraciones> Configuraciones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones para Sucursales
            modelBuilder.Entity<Sucursales>()
                // Relación con Tipos
                .HasOne(s => s.Tipos)          // Una sucursal tiene un tipo
                .WithMany()                    // Un tipo puede tener muchas sucursales
                .HasForeignKey(s => s.IdTipo)  // Clave foránea es IdTipo
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento de eliminación en cascada

            // Relación con Provincias
            modelBuilder.Entity<Sucursales>()
                .HasOne(s => s.Provincias)          // Una sucursal tiene una provincia
                .WithMany()                         // Una provincia puede tener muchas sucursales
                .HasForeignKey(s => s.IdProvincia)  // Clave foránea es IdProvincia
                .OnDelete(DeleteBehavior.Cascade);  // Comportamiento de eliminación en cascada

            // Configuraciones adicionales de tabla
            modelBuilder.Entity<Sucursales>()
                .Property(s => s.Nombre)
                .IsRequired();  // Nombre es obligatorio

            modelBuilder.Entity<Sucursales>()
                .Property(s => s.Telefono)
                .IsRequired();  // Teléfono es obligatorio


            // Definir GUIDs predefinidos para evitar cambios constantes
            var cordobaId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001");
            var bsAsId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002");
            var saltaId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003");

            var pequeniaId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004");
            var grandeId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005");

            var configTopId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006");
            var configLeftId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007");

            // Seed Provincias
            modelBuilder.Entity<Provincias>().HasData(
                new Provincias { Id = cordobaId, Nombre = "Córdoba" },
                new Provincias { Id = bsAsId, Nombre = "Buenos Aires" },
                new Provincias { Id = saltaId, Nombre = "Salta" }
            );

            // Seed Tipos
            modelBuilder.Entity<Tipos>().HasData(
                new Tipos { Id = pequeniaId, Nombre = "Pequeña" },
                new Tipos { Id = grandeId, Nombre = "Grande" }
            );

            // Seed Configuraciones
            modelBuilder.Entity<Configuraciones>().HasData(
                new Configuraciones
                {
                    Id = configTopId,
                    Nombre = "padding-top",
                    Valor = "50px"
                },
                new Configuraciones
                {
                    Id = configLeftId,
                    Nombre = "padding-left",
                    Valor = "100px"
                }
            );

            // Seed Sucursales con GUIDs predefinidos para cada sucursal
            modelBuilder.Entity<Sucursales>().HasData(
                new Sucursales
                {
                    Id = Guid.Parse("c64c4900-901b-4241-99b4-ae2274235f7b"),
                    Nombre = "Sucursal Córdoba Centro",
                    IdCiudad = "CBA001",
                    IdTipo = pequeniaId,
                    IdProvincia = cordobaId,
                    Telefono = "0351-4567890",
                    NombreTitular = "María",
                    ApellidoTitular = "Gómez",
                    FechaAlta = DateTime.Now
                },
               
                new Sucursales
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    Nombre = "Sucursal Córdoba norte",
                    IdCiudad = "CBA5551",
                    IdTipo = grandeId,
                    IdProvincia = cordobaId,
                    Telefono = "0351-45678888",
                    NombreTitular = "Joaquin",
                    ApellidoTitular = "Gómez",
                    FechaAlta = DateTime.Now
                },
                 new Sucursales
                 {
                     Id = Guid.Parse("4b9530b2-30e3-4acf-91b8-5ec2efcc24fd"),
                     Nombre = "Sucursal Córdoba sur",
                     IdCiudad = "CB661",
                     IdTipo = grandeId,
                     IdProvincia = cordobaId,
                     Telefono = "0351-45678888",
                     NombreTitular = "Joaquin",
                     ApellidoTitular = "Gómez",
                     FechaAlta = DateTime.Now
                 },
                  new Sucursales
                  {
                      Id = Guid.Parse("5c9a4b0f-6554-40ff-a906-35b54a1daedc"),
                      Nombre = "Sucursal Córdoba Oeste",
                      IdCiudad = "CB221",
                      IdTipo = grandeId,
                      IdProvincia = cordobaId,
                      Telefono = "0351-45678888",
                      NombreTitular = "Joaquin",
                      ApellidoTitular = "Gómez",
                      FechaAlta = DateTime.Now
                  },
                   new Sucursales
                   {
                       Id = Guid.Parse("0a900986-a6b9-4622-bbb2-b46078b01baf"),
                       Nombre = "Sucursal Córdoba Oeste",
                       IdCiudad = "BA001",
                       IdTipo = grandeId,
                       IdProvincia = bsAsId,
                       Telefono = "11-45678228",
                       NombreTitular = "Joaquin",
                       ApellidoTitular = "Gómez",
                       FechaAlta = DateTime.Now
                   },
                    new Sucursales
                    {
                        Id = Guid.Parse("f9ce11fd-e42f-4bb1-a1bb-6921e0349950"),
                        Nombre = "Sucursal salta Oeste",
                        IdCiudad = "SA777",
                        IdTipo = grandeId,
                        IdProvincia = saltaId,
                        Telefono = "88-4567887448",
                        NombreTitular = "Joaquin",
                        ApellidoTitular = "Gómez",
                        FechaAlta = DateTime.Now
                    },
                     new Sucursales
                     {
                         Id = Guid.Parse("43588888-df4b-4a51-9dc7-4b81aa0cc6c6"),
                         Nombre = "Sucursal salta Oeste",
                         IdCiudad = "SA1",
                         IdTipo = grandeId,
                         IdProvincia = saltaId,
                         Telefono = "88-45673388",
                         NombreTitular = "Joaquin",
                         ApellidoTitular = "Gómez",
                         FechaAlta = DateTime.Now
                     }

            );

            base.OnModelCreating(modelBuilder);
        }
    
        }
    }
