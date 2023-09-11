using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.EntidadesDeNegocio
{
    public class Libros
    {
        public int id { get; set; }
        public int IdQuiz { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Categoria { get; set; }
        public string Imagen { get; set; }
    }
}
