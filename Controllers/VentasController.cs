using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMasterIdentity.Models;

namespace WebMasterIdentity.Controllers
{
    [Authorize]
    public class VentasController : Controller
    {
        private readonly DBContext _context;

        public VentasController(DBContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Ventas.Include(v => v.Producto).Include(v => v.Tienda);
            return View(await dBContext.ToListAsync());
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
