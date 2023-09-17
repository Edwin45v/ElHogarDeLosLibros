using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElHogar_DeLos_Libros.AccesoADatos;
using ElHogar_DeLos_Libros.EntidadesDeNegocio;

namespace ElHogar_DeLos_Libros.LogicaDeNegocio
{
    public class AlumnosBL
    {
        public async Task<int> CrearAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.CrearAsync(pAlumnos);
        }
        public async Task<int> ModificarAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.ModificarAsync(pAlumnos);
        }
        public async Task<int> EliminarAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.EliminarAsync(pAlumnos);
        }
        public async Task<Alumnos> ObtenerPorIdAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.ObtenerPorIdAsync(pAlumnos);
        }
        public async Task<List<Alumnos>> ObtenerTodosAsync()
        {
            return await AlumnosDAL.ObtenerTodosAsync();
        }
        public async Task<List<Alumnos>> BuscarAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.BuscarAsync(pAlumnos);
        }
        public async Task<List<Alumnos>> BuscarIncluirGradoAsync(Alumnos pAlumnos)
        {
            return await AlumnosDAL.BuscarIncluirGradosAsync(pAlumnos);
        }
    }
}
