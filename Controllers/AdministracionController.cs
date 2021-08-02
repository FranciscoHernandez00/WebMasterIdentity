using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMasterIdentity.Models;

namespace WebMasterIdentity.Controllers
{

    [Authorize]
    public class AdministracionController : Controller
    {
        private readonly DBContext _context;

        public AdministracionController(DBContext context)
        {
            _context = context;
        }


        public IActionResult DashBoard()
        {
            ViewBag.Suma = _context.Ventas.Select(x => x.Total).Sum();
            ViewBag.Cantidad = _context.Ventas.Select(x => x.Cantidad).Sum();
            ViewBag.Categorias = _context.Ventas.Select(x => x.Producto.CategoriaId).Count();
            return View();
        }

        public IActionResult RealizarVenta()
        {
            List<Producto> ListaProductos = _context.Productos.ToList();
            ViewBag.Productos = new SelectList(ListaProductos, "ProductoId", "NombreProducto");
            List<Tienda> ListaTienda = _context.Tiendas.ToList();
            ViewBag.Tiendas = new SelectList(ListaTienda, "TiendaId", "NombreTienda");
            return View();
        }

        [HttpPost]
        public JsonResult GuardarVenta(int producto, int cantidad, int tienda, decimal total)
        {
            Venta venta = new Venta();
            venta.ProductoId = producto;
            venta.Cantidad = cantidad;
            venta.TiendaId = tienda;
            venta.Total = total;
            venta.Fecha = DateTime.Now;

            _context.Ventas.Add(venta);
            _context.SaveChanges();
            return Json(new { Mensaje = "¡Venta Guardada con exito!" });
        }

        [HttpPost]
        public JsonResult GetShopList(int Id)
        {
            var PrecioBase = _context.Productos.Where(x => x.ProductoId == Id).Select(x => new { x.Precio, x.NombreProducto }).FirstOrDefault();
          
            return Json(PrecioBase);
        }
    }
}