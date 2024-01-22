using APIProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Data
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options 
            ) : base( options ) { }
            
        
        public DbSet<Tarea> Tareas { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasData(

                new Tarea
                {
                    IdTarea = 1,
                    Nombre = "Gorky",
                    Estado = "Por Hacer",
                    Actividad = "Realizar el examen"
                }


                ); ;
 ;
		}
    }
}
