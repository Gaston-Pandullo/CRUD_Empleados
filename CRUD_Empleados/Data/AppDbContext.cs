using CRUD_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleados.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(table =>
            {
                table.HasKey(col => col.Id);

                // Aca se configura con Identity, que el valor de la columna aumenta de a 1
                // y que se genera un valor cuando se agrega una entidad nueva.
                table.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                // Configuracion de columna de nombre.
                table.Property(col => col.NombreCompleto)
                .HasMaxLength(50);

                // Configuracion de columna de correo.
                table.Property(col => col.Correo)
                .HasMaxLength(50);
            });

            // Si se quiere colocar un nombre DISTINTO de la clase:

            //modelBuilder.Entity<Empleado>().ToTable("Nombre");
        }
    }
}
