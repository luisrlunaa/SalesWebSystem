using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Gastos
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        [Required]
        public string monto { get; set; }
        public DateTime fecha { get; set; }

        public Gastos()
        {
        }
    }
}
