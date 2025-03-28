using Microsoft.EntityFrameworkCore;
namespace L01P02_2022CG650.Models
{
    public class NotasContext : DbContext
    {

        public NotasContext(DbContextOptions options) : base(options) { }

        public DbSet<alumnosModel> alumnos { get; set; }
        public DbSet<facultades> facultades { get; set; }
        public DbSet<departamentosModel> departamentos { get; set; }
        public DbSet<materiasModel> materias { get; set; }
    }
}
