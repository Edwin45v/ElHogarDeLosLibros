using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.EntidadesDeNegocio
{
    public class Grado
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        
        public string Nombre { get; set; }

        [NotMapped]

        public int Top_Aux { get; set; }

        public List<Alumnos> Alumnos { get; set; }

    }
}
