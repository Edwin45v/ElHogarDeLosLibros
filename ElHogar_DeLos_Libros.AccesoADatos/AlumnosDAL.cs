using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos

{
    public class AlumnosDAL
    {

        public static async Task<int> CrearAsync(Alumnos pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pAlumnos);
                result = await bdContexto.SaveChangesAsync();
               
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Alumnos pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var alumnos = await bdContexto.Alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
                alumnos.GradoId = pAlumnos.GradoId;
                alumnos.Nombre = pAlumnos.Nombre;
                alumnos.Apellido = pAlumnos.Apellido;
                alumnos.Imagen = pAlumnos.Imagen;
                bdContexto.Update(alumnos);
                result = await bdContexto.SaveChangesAsync();

            }
            return result;
        }

        public static async Task<int> EliminarAsync(Alumnos pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var alumnos = await bdContexto.Alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
                bdContexto.Alumnos.Remove(alumnos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Alumnos> ObtenerPorIdAsync(Alumnos pAlumnos)
        {
            var alumnos = new Alumnos();
            using (var bdContexto = new BDContexto())
            {
                alumnos = await bdContexto.Alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
            }
            return alumnos;
        }

        public static async Task<List<Alumnos>> ObtenerTodosAsync()
        {
            var alumnos = new List<Alumnos>();
            using (var bdContexto = new BDContexto())
            {
                alumnos = await bdContexto.Alumnos.ToListAsync();
            }
            return alumnos;
        }

        internal static IQueryable<Alumnos> QuerySelect(IQueryable<Alumnos> pQuery, Alumnos pAlumnos)
        {
            if (pAlumnos.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pAlumnos.Id);
            if (pAlumnos.GradoId > 0)
                pQuery = pQuery.Where(s => s.GradoId == pAlumnos.GradoId);
            if (!string.IsNullOrWhiteSpace(pAlumnos.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pAlumnos.Nombre));
            if (!string.IsNullOrWhiteSpace(pAlumnos.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pAlumnos.Apellido));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pAlumnos.Top_Aux > 0)
                pQuery = pQuery.Take(pAlumnos.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Alumnos>> BuscarAsync(Alumnos pAlumnos)
        {
            var alumnos = new List<Alumnos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Alumnos.AsQueryable();
                select = QuerySelect(select, pAlumnos);
                alumnos = await select.ToListAsync();
            }
            return alumnos;
        }

        public static async Task<List<Alumnos>> BuscarIncluirGradosAsync(Alumnos pAlumnos)
        {
            var alumnos = new List<Alumnos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Alumnos.AsQueryable();
                select = QuerySelect(select, pAlumnos).Include(s => s.GradoId).AsQueryable();
                alumnos = await select.ToListAsync();
            }
            return alumnos;
        }

    }
}
