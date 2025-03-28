using System.ComponentModel.DataAnnotations;
namespace L01P02_2022CG650.Models
{
    public class facultades
    {

        [Key]
        public int id { get; set; }
        [Display(Name = "Facultad de la universidad")]
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string? facultad {  get; set; }
    }
}
