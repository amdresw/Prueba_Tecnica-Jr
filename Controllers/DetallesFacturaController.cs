using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturacionMVC.Models;

namespace FacturacionMVC.Controllers
{
    public class DetallesFacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesFacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallesFactura
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallesFactura.Include(d => d.Factura).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallesFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetallesFactura
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetallesFactura/Create
        public IActionResult Create()
        {
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Codigo");
            return View();
        }

        // POST: DetallesFactura/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFactura,IdProducto,Cantidad,PrecioUnitario")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Codigo", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // GET: DetallesFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetallesFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Codigo", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // POST: DetallesFactura/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFactura,IdProducto,Cantidad,PrecioUnitario")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Codigo", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // GET: DetallesFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetallesFactura
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetallesFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetallesFactura.FindAsync(id);
            if (detalleFactura != null)
            {
                _context.DetallesFactura.Remove(detalleFactura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetallesFactura.Any(e => e.Id == id);
        }
    }
}
