using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMasterIdentity.Models
{
    public class Tienda
    {
        [Key]
        public int TiendaId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Campo Requerido.")]
        public string NombreTienda { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Direccion { get; set; }
    }
}
