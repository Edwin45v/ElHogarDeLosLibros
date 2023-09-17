using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using ElHogar_DeLos_Libros.LogicaDeNegocio;
using ElHogar_DeLos_Libros.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ElHogar_DeLos_Libros.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LibrosController : ControllerBase
    {
        private LibrosBL librosBL = new LibrosBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationService authService;
        public LibrosController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Libros>> Get()
        {
            return await librosBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Libros> Get(int id)
        {
            Libros libros = new Libros();
            libros.Id = id;
            return await librosBL.ObtenerPorIdAsync(libros);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Libros libros)
        {
            try
            {
                await librosBL.CrearAsync(libros);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pLibros)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuario = JsonSerializer.Serialize(pLibros);
            Libros libros = JsonSerializer.Deserialize<Libros>(strUsuario, option);
            if (libros.Id == id)
            {
                await librosBL.ModificarAsync(libros);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Libros libros = new Libros();
                libros.Id = id;
                await librosBL.EliminarAsync(libros);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Libros>> Buscar([FromBody] object pLibros)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strLibros = JsonSerializer.Serialize(pLibros);
            Libros libros = JsonSerializer.Deserialize<Libros>(strLibros, option);
            var libro = await librosBL.BuscarIncluirQUIZAsync(libros);
            libro.ForEach(s => s.QUIZ.Libros = null); // Evitar la redundacia de datos
            return libro;
        }

        
    }
}
