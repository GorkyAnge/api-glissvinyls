using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Tarea
    {
        [Key]

        public int IdTarea { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Actividad { get; set; }
    }
}
