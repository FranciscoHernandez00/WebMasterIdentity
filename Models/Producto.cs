using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMasterIdentity.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string NombreProducto { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
