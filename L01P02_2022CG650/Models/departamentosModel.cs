using System.ComponentModel.DataAnnotations;
namespace L01P02_2022CG650.Models
{
    public class departamentosModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? departamento { get; set; }
    }
}
