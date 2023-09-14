using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.EntidadesDeNegocio
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Grado")]
        [Required(ErrorMessage = "El grado es requerido")]
        [Display(Name = "Grado")]
        public int GradoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La imagen es requerido")]
        [MaxLength(200, ErrorMessage = "El largo maximo es 200 caracteres")]
        public string Imagen { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public Alumnos Grado { get; set; }
    }
}

