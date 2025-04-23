using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Caja
    {
        [Key]
        public int id_caja { get; set; }
        public decimal monto_inicial { get; set; }
        public decimal monto_final { get; set; }
        public decimal montoactual { get; set; }
        public decimal deuda { get; set; }
        public DateTime fecha { get; set; }

        public Caja()
        {
        }
    }
}
