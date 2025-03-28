using System.ComponentModel.DataAnnotations;
namespace L01P02_2022CG650.Models
{
    public class alumnosModel
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Codigo de Estudiante")]
        [Required(ErrorMessage ="Este campo es obligatiorio")]
        public string? codigo { get; set; }
        [Display(Name = "Nombre del estudiante")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? nombre { get; set; }
        [Display(Name = "Apellidos del estudiante ")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? apellidos { get; set; }
        [Display(Name = "Dui del estudiante")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public int dui { get; set; }
        [Display(Name = "Estado el estudiante 1= Activo , 0= Inactivo")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public int estado { get; set; }
    }
}
