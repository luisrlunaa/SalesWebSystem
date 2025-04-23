using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Tipo_factura
    {
        [Key]
        public int id { get; set; }
        public string Descripcion { get; set; }

        public Tipo_factura()
        {
        }
    }
}
