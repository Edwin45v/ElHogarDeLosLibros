using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElHogar_DeLos_Libros.AccesoADatos;
using ElHogar_DeLos_Libros.EntidadesDeNegocio;

namespace ElHogar_DeLos_Libros.LogicaDeNegocio
{
    public class QUIZBL
    {
        public async Task<int> CrearAsync(QUIZ pQUIZ)
        {
            return await QUIZDAL.CrearAsync(pQUIZ);
        }
        public async Task<int> ModificarAsync(QUIZ pQUIZ)
        {
            return await QUIZDAL.ModificarAsync(pQUIZ);
        }
        public async Task<int> EliminarAsync(QUIZ pQUIZ)
        {
            return await QUIZDAL.EliminarAsync(pQUIZ);
        }
        public async Task<QUIZ> ObtenerPorIdAsync(QUIZ pQUIZ)
        {
            return await QUIZDAL.ObtenerPorIdAsync(pQUIZ);
        }
        public async Task<List<QUIZ>> ObtenerTodosAsync()
        {
            return await QUIZDAL.ObtenerTodosAsync();
        }
        public async Task<List<QUIZ>> BuscarAsync(QUIZ pQUIZ)
        {
            return await QUIZDAL.BuscarAsync(pQUIZ);
        }
    }
}
