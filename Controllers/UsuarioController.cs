using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : Controller
	{
		
		private readonly ApplicationDBContext _db;

		//Constructor
		public UsuarioController(ApplicationDBContext db)
		{
			_db = db;
		}

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Usuario> usuarios = await _db.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{Correo}/{Contrasenia}")]
		public async Task<IActionResult> Get(string Correo, string Contrasenia)
		{

			Usuario usuario_encontrado = await _db.Usuarios.Where(x => x.Correo == Correo && x.Contrasenia == Contrasenia).FirstOrDefaultAsync();

			if (usuario_encontrado == null)
			{
				return BadRequest();
			}
			return Ok(usuario_encontrado);
		}

        // GET api/<ProductoController>/5
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> Get(int IdUsuario)
        {

            Usuario usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);

            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }

        [HttpPost]
		public async Task<IActionResult> Post([FromBody] Usuario usuario)
		{
			_db.Usuarios.Add(usuario);
			await _db.SaveChangesAsync();
			return Ok(usuario);

		}

        // PUT: api/Usuario/5
        [HttpPut("{IdUsuario}")]
        public async Task<ActionResult> Put(int IdUsuario, [FromBody] Usuario usuario)
        {
            var usuarioEncontrado = await _db.Usuarios.FirstOrDefaultAsync(p => p.IdUsuario == IdUsuario);
            if (usuarioEncontrado is null) return NotFound();

            usuarioEncontrado.Nombre = usuario.Nombre ?? usuarioEncontrado.Nombre;
            usuarioEncontrado.Apellidos = usuario.Apellidos ?? usuarioEncontrado.Apellidos;
            usuarioEncontrado.Correo = usuario.Correo;
            usuarioEncontrado.Contrasenia = usuario.Contrasenia;
            usuarioEncontrado.Rol = usuario.Rol ?? usuarioEncontrado.Rol;
            _db.Usuarios.Update(usuarioEncontrado);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(p => p.IdUsuario == IdUsuario);
            if (usuario is null) return NotFound();
            _db.Usuarios.Remove(usuario);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

