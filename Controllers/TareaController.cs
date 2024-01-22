using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly ApplicationDBContext _db;

        public TareaController(ApplicationDBContext db)
        {
            _db = db;

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            var tareaEncontrada = await _db.Tareas.FirstOrDefaultAsync(p => p.IdTarea == tarea.IdTarea);
            if (tarea == null || tareaEncontrada != null) return BadRequest();
            await _db.Tareas.AddAsync(tarea);
            await _db.SaveChangesAsync();
            return Ok(tarea);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Tarea> productos = await _db.Tareas.ToListAsync();
            return Ok(productos);
        }

       
    }
}
