using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMasterIdentity.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Total { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
        public List<Producto> Productos { get; set;}
    }
}
