using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos

{
    public class AlumnosDAL
    {

        public static async Task<int> CrearAsync(AlumnosDAL pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pAlumnos);
                result = await bdContexto.SaveChangesAsync();
               
            }
            return result;
        }

        public static async Task<int> ModificarAsync(AlumnosDAL pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var alumnos = await bdContexto.alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
                alumnos.IdGrado = pAlumno.IdGrado;
                alumnos.Nombre = pAlumnos.Nombre;
                alumnos.Apellido = pAlumnos.Apellido;
                alumnos.imagen = pAlumnos.imagen;
                bdContexto.Update(alumnos);
                result = await bdContexto.SaveChangesAsync();

            }
            return result;
        }

        public static async Task<int> EliminarAsync(AlumnosDAL pAlumnos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var alumnos = await bdContexto.alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
                bdContexto.alumnos.Remove(alumnos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<alumnos> ObtenerPorIdAsync(AlumnosDAL pAlumnos)
        {
            var alumnos = new alumnos();
            using (var bdContexto = new BDContexto())
            {
                alumnos = await bdContexto.alumnos.FirstOrDefaultAsync(s => s.Id == pAlumnos.Id);
            }
            return alumnos;
        }

        public static async Task<List<alumnos>> ObtenerTodosAsync()
        {
            var alumnos = new List<alumnos>();
            using (var bdContexto = new BDContexto())
            {
                alumnos = await bdContexto.alumnos.ToListAsync();
            }
            return alumnos;
        }

        internal static IQueryable<alumnos> QuerySelect(IQueryable<alumnos> pQuery, alumnos pAlumnos)
        {
            if (pAlumnos.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pAlumnos.Id);
            if (pAlumnos.IdGrado > 0)
                pQuery = pQuery.Where(s => s.IdGrado == pAlumnos.IdGrado);
            if (!string.IsNullOrWhiteSpace(pAlumnos.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pAlumnos.Nombre));
            if (!string.IsNullOrWhiteSpace(pAlumnos.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pAlumnos.Apellido));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pAlumnos.Top_Aux > 0)
                pQuery = pQuery.Take(pAlumnos.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<alumnos>> BuscarAsync(alumnos pAlumnos)
        {
            var alumnos = new List<alumnos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.alumnos.AsQueryable();
                select = QuerySelect(select, pAlumnos);
                alumnos = await select.ToListAsync();
            }
            return alumnos;
        }

        public static async Task<List<alumnos>> BuscarIncluirGradosAsync(alumnos pAlumnos)
        {
            var alumnos = new List<alumnos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.alumnos.AsQueryable();
                select = QuerySelect(select, pAlumnos).Include(s => s.Grados).AsQueryable();
                alumnos = await select.ToListAsync();
            }
            return alumnos;
        }

    }
}
