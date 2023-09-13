using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos
{
    public class LibrosDAL
    {
        public static async Task<int> CrearAsync(Libros pLibros)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pLibros);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Libros pLibros)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var libros = await bdContexto.Libros.FirstOrDefaultAsync(s => s.Id == pLibros.Id);
                libros.IdQuiz = pLibros.IdQuiz;
                libros.Nombre = pLibros.Nombre;
                libros.Autor = pLibros.Autor;
                libros.Categoria = pLibros.Categoria;
                libros.Imagen = pLibros.Imagen;
                bdContexto.Update(libros);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Libros pLibros)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var libros = await bdContexto.Libros.FirstOrDefaultAsync(s => s.Id == pLibros.Id);
                bdContexto.Libros.Remove(libros);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Libros> ObtenerPorIdAsync(Libros pLiros)
        {
            var libros = new Libros();
            using (var bdContexto = new BDContexto())
            {
                libros = await bdContexto.Libros.FirstOrDefaultAsync(s => s.Id == pLiros.Id);
            }
            return libros;
        }

        public static async Task<List<Libros>> ObtenerTodosAsync()
        {
            var libros = new List<Libros>();
            using (var bdContexto = new BDContexto())
            {
                libros = await bdContexto.Libros.ToListAsync();
            }
            return libros;
        }

        internal static IQueryable<Libros> QuerySelect(IQueryable<Libros> pQuery, Libros pLibros)
        {
            if (pLibros.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pLibros.Id);
            if (pLibros.IdQuiz > 0)
                pQuery = pQuery.Where(s => s.IdQuiz == pLibros.IdQuiz);
            if (!string.IsNullOrWhiteSpace(pLibros.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pLibros.Nombre));
            if (!string.IsNullOrWhiteSpace(pLibros.Autor))
                pQuery = pQuery.Where(s => s.Autor.Contains(pLibros.Autor));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pLibros.Top_Aux > 0)
                pQuery = pQuery.Take(pLibros.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Libros>> BuscarAsync(Libros pLibros)
        {
            var libros = new List<Libros>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libros.AsQueryable();
                select = QuerySelect(select, pLibros);
                libros = await select.ToListAsync();
            }
            return libros;
        }

        public static async Task<List<Libros>> BuscarIncluirQUIZAsync(Libros pLibros)
        {
            var libros = new List<Libros>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libros.AsQueryable();
                select = QuerySelect(select, pLibros).Include(s => s.QUIZ).AsQueryable();
                libros = await select.ToListAsync();
            }
            return libros;
        }
    }

}
