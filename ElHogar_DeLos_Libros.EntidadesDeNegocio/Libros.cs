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
        [Key]
        public int Id { get; set; }

        [ForeignKey("QUIZ")]
        [Required(ErrorMessage = "El QUIZ es requerido")]
        [Display(Name = "QUIZ")]
        public int IdQuiz { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caratesres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El autor es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caratesres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Categoria { get; set; }

        [Required(ErrorMessage = "La imagen es requerido")]
        [MaxLength(200, ErrorMessage = "El largo maximo es 200 caratesres")]
        public string Imagen { get; set; }
        [NotMapped ]
        public int top_aux { get; set; }
        public QUIZ QUIZ { get; set; }
    }
    public enum Categoria_Libros
    {
        Cuentos = 1,
        Ficcion = 2,
        Leyendas = 3,
        Terror = 4,
        Poesia = 5,
        Novela = 6,
        Obra = 7,
        Suspenso = 8
    }
}
