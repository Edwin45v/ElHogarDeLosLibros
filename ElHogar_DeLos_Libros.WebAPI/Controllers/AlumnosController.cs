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
    public class AlumnosController : ControllerBase
    {
        private AlumnosBL alumnosBL = new AlumnosBL();

        private readonly IJwtAuthenticationService authService;
        public AlumnosController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Alumnos>> Get()
        {
            return await alumnosBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Alumnos> Get(int id)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.Id = id;
            return await alumnosBL.ObtenerPorIdAsync(alumnos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Alumnos alumnos)
        {
            try
            {
                await alumnosBL.CrearAsync(alumnos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pAlumnos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strAlumnos = JsonSerializer.Serialize(pAlumnos);
            Alumnos alumnos = JsonSerializer.Deserialize<Alumnos>(strAlumnos, option);
            if (alumnos.Id == id)
            {
                await alumnosBL.ModificarAsync(alumnos);
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
                Alumnos alumnos = new Alumnos();
                alumnos.Id = id;
                await alumnosBL.EliminarAsync(alumnos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Alumnos>> Buscar([FromBody] object pAlumnos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strAlumnos = JsonSerializer.Serialize(pAlumnos);
            Alumnos alumno = JsonSerializer.Deserialize<Alumnos>(strAlumnos, option);
            var alumnos = await alumnosBL.BuscarIncluirGradoAsync(alumno);
            alumnos.ForEach(s => s.Grado.Alumnos = null);
            return alumnos;
        }
    }
}
