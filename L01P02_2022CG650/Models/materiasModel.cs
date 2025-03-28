
using System.ComponentModel.DataAnnotations;
namespace L01P02_2022CG650.Models
{
    public class materiasModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Materia a cursar")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? materia { get; set; }
        [Display(Name = "Unidades Valorativas")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public int unidades_valorativas { get; set; }
        [Display(Name = "Estado A = Aprobado y R = Reprovado")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? estado { get; set; } 

    }
}
