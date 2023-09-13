using Microsoft.EntityFrameworkCore;
using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos
{
    public class QUIZDAL
    {
        public static async Task<int> CrearAsync(QUIZ pQUIZ)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pQUIZ);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(QUIZ pQUIZ)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var quiz = await bdContexto.QUIZ.FirstOrDefaultAsync(s => s.Id == pQUIZ.Id);
                quiz.Pregunta = pQUIZ.Pregunta;
                quiz.Respuesta = pQUIZ.Respuesta;
                bdContexto.Update(quiz);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(QUIZ pQUIZ)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var quiz = await bdContexto.QUIZ.FirstOrDefaultAsync(s => s.Id == pQUIZ.Id);
                bdContexto.QUIZ.Remove(quiz);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<QUIZ> ObtenerPorIdAsync(QUIZ pQUIZ)
        {
            var quiz = new QUIZ();
            using (var bdContexto = new BDContexto())
            {
                quiz = await bdContexto.QUIZ.FirstOrDefaultAsync(s => s.Id == pQUIZ.Id);
            }
            return quiz;
        }

        public static async Task<List<QUIZ>> ObtenerTodosAsync()
        {
            var quiz = new List<QUIZ>();
            using (var bdContexto = new BDContexto())
            {
                quiz = await bdContexto.QUIZ.ToListAsync();
            }
            return quiz;
        }

        internal static IQueryable<QUIZ> QuerySelect(IQueryable<QUIZ> pQuery, QUIZ pQUIZ)
        {
            if (pQUIZ.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pQUIZ.Id);

            if (!string.IsNullOrWhiteSpace(pQUIZ.Pregunta))
                pQuery = pQuery.Where(s => s.Pregunta.Contains(pQUIZ.Pregunta));

            if (!string.IsNullOrWhiteSpace(pQUIZ.Respuesta))
                pQuery = pQuery.Where(s => s.Respuesta.Contains(pQUIZ.Respuesta));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pQUIZ.Top_Aux > 0)
                pQuery = pQuery.Take(pQUIZ.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<QUIZ>> BuscarAsync(QUIZ pQUIZ)
        {
            var quiz = new List<QUIZ>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.QUIZ.AsQueryable();
                select = QuerySelect(select, pQUIZ);
                quiz = await select.ToListAsync();
            }
            return quiz;
        }
    }
}
