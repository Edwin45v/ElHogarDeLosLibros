﻿using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos
{
    public class GradoDAL
    {
        public static async Task<int> CrearAsync(Grado pGrado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pGrado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Grado pGrado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var grado = await bdContexto.Grado.FirstOrDefaultAsync(s => s.Id == pGrado.Id);
                grado.Nombre = pGrado.Nombre;
                bdContexto.Update(grado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Grado pGrado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var grado = await bdContexto.Grado.FirstOrDefaultAsync(s => s.Id == pGrado.Id);
                bdContexto.Grado.Remove(grado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Grado> ObtenerPorIdAsync(Grado pGrado)
        {
            var grado = new Grado();
            using (var bdContexto = new BDContexto())
            {
                grado = await bdContexto.Grado.FirstOrDefaultAsync(s => s.Id == pGrado.Id);
            }
            return grado;
        }

        public static async Task<List<Grado>> ObtenerTodosAsync()
        {
            var grado = new List<Grado>();
            using (var bdContexto = new BDContexto())
            {
                grado = await bdContexto.Grado.ToListAsync();
            }
            return grado;
        }

        internal static IQueryable<Grado> QuerySelect(IQueryable<Grado> pQuery, Grado pGrado)
        {
            if (pGrado.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pGrado.Id);

            if (!string.IsNullOrWhiteSpace(pGrado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pGrado.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pGrado.Top_Aux > 0)
                pQuery = pQuery.Take(pGrado.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Grado>> BuscarAsync(Grado pGrado)
        {
            var grado = new List<Grado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Grado.AsQueryable();
                select = QuerySelect(select, pGrado);
                grado = await select.ToListAsync();
            }
            return grado;
        }
    }
}
