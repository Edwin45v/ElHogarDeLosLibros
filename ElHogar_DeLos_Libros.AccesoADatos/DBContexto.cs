using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<QUIZ> QUIZ { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NROUOQ6;Initial Catalog=ElHogarDeLosLibros3;Integrated Security=True");
        }
    }
}
