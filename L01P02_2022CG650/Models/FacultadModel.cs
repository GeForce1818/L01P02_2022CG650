using System.ComponentModel.DataAnnotations;
namespace L01P02_2022CG650.Models
{
    public class FacultadModel
    {

        [Key]
        public int id { get; set; }
        public string? facultad {  get; set; }
    }
}
