using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using ElHogar_DeLos_Libros.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ElHogar_DeLos_Libros.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QUIZController : ControllerBase
    {
        private QUIZBL qUIZBL = new QUIZBL();

        [HttpGet]
        public async Task<IEnumerable<QUIZ>> Get()
        {
            return await qUIZBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<QUIZ> Get(int id)
        {
            QUIZ qUIZ = new QUIZ();
            qUIZ.Id = id;
            return await qUIZBL.ObtenerPorIdAsync(qUIZ);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QUIZ qUIZ)
        {
            try
            {
                await qUIZBL.CrearAsync(qUIZ);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] QUIZ qUIZ)
        {

            if (qUIZ.Id == id)
            {
                await qUIZBL.ModificarAsync(qUIZ);
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
                QUIZ qUIZ = new QUIZ();
                qUIZ.Id = id;
                await qUIZBL.EliminarAsync(qUIZ);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<QUIZ>> Buscar([FromBody] object pQUIZ)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strQUIZ = JsonSerializer.Serialize(pQUIZ);
            QUIZ qUIZ = JsonSerializer.Deserialize<QUIZ>(strQUIZ, option);
            return await qUIZBL.BuscarAsync(qUIZ);

        }

    }
}
