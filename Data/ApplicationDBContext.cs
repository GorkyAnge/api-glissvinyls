using APIProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Data
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options 
            ) : base( options ) { }
            
        
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(

                new Producto
                {
                    IdProducto =1,
                    Nombre="Producto1",
                    Descripcion="Desc1",
                    Stock=13,
                    Precio=0,
                    Imagen= "https://images.ctfassets.net/63bmaubptoky/8e6EHyyhZoA2rEb_gcW_Wqp1UYa-QFOfol6A_hLTDo4/d07539f9788941b43e301c741bc144ce/what-is-software-CA-Capterra-Header.png"
                }


                );
        }
    }
}
