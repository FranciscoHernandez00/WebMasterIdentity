using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMasterIdentity.Models
{
    public class DBContext:DbContext
    {

        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}