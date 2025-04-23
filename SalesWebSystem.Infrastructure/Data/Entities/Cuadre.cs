using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Cuadre
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        [Required]
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }

        public Cuadre()
        {
        }
    }
}
