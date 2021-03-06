using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMasterIdentity.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string NombreCategoria { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Descripcion { get; set; }
    }
}
