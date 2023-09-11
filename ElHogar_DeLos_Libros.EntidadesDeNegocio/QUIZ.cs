using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.EntidadesDeNegocio
{
    public class QUIZ
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tu pregunta es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Pregunta { get; set; }


        [Required(ErrorMessage = "Tu respuesta  es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Respuesta { get; set; }



        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libros> Libros { get; set; }
    }
}
