using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElHogar_DeLos_Libros.AccesoADatos;
using ElHogar_DeLos_Libros.EntidadesDeNegocio;

namespace ElHogar_DeLos_Libros.LogicaDeNegocio
{
    public class LibrosBL
    {
        public async Task<int> CrearAsync(Libros pLibros)
        {
            return await LibrosDAL.CrearAsync(pLibros);
        }
        public async Task<int> ModificarAsync(Libros pLibros)
        {
            return await LibrosDAL.ModificarAsync(pLibros);
        }
        public async Task<int> EliminarAsync(Libros pLibros)
        {
            return await LibrosDAL.EliminarAsync(pLibros);
        }
        public async Task<Libros> ObtenerPorIdAsync(Libros pLibros)
        {
            return await LibrosDAL.ObtenerPorIdAsync(pLibros);
        }
        public async Task<List<Libros>> ObtenerTodosAsync()
        {
            return await LibrosDAL.ObtenerTodosAsync();
        }
        public async Task<List<Libros>> BuscarAsync(Libros pLibros)
        {
            return await LibrosDAL.BuscarAsync(pLibros);
        }
        public async Task<List<Libros>> BuscarIncluirQUIZAsync(Libros pLibros)
        {
            return await LibrosDAL.BuscarIncluirQUIZAsync(pLibros);
        }
    }
}
