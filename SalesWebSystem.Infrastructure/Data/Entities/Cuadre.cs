using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public int id_business { get; set; }

        public Cuadre()
        {
        }
    }
}
