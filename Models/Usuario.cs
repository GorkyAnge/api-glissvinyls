using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
	public class Usuario
	{
		[Key]
		public int IdUsuario { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Apellidos { get; set; }
		[Required]
		public string Correo { get; set; }
		[Required]
		public string Contrasenia { get; set; }
		[Required]
		public string Rol { get; set; }


	}
}
