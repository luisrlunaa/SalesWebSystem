using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Tipo_trabajo
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string descripcion { get; set; }

        public Tipo_trabajo()
        {
        }
    }
}
