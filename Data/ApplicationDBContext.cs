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
		public DbSet<Usuario> Usuarios { get; set; }
		//public DbSet<Carrito> Carritos { get; set; }
		public DbSet<Resena> Resenas { get; set; }
		public DbSet<ProductoEnCarrito> ProductosEnCarrito { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(

                new Producto
                {
                    IdProducto =1,
                    Nombre="Producto1",
                    Descripcion="Desc1",
                    Stock=13,
                    Precio=50,
                    Imagen= "https://images.ctfassets.net/63bmaubptoky/8e6EHyyhZoA2rEb_gcW_Wqp1UYa-QFOfol6A_hLTDo4/d07539f9788941b43e301c741bc144ce/what-is-software-CA-Capterra-Header.png"
                }


                );

			modelBuilder.Entity<Usuario>().HasData(

			   new Usuario
			   {
				   IdUsuario = 1,
				   Nombre = "Admin",
                   Apellidos = "Admin",
				   Correo = "admin@gmail.com",
				   Contrasenia = "empanada123",
				   Rol = "admin",

			   }
			   ); ;
		}
    }
}
