using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturacionMVC.Models;

namespace FacturacionMVC.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Facturas.Include(f => f.Cliente).Include(f => f.Emisor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Emisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        
        // GET: Facturas/Create
            public IActionResult Create()
            {
                ViewData["IdCliente"] = new SelectList(
                    _context.Clientes.Select(c => new
                    {
                        c.Id,
                        NombreCompleto = c.Nombres + " " + c.Apellidos
                    }),
                    "Id",
                    "NombreCompleto"
                );

                ViewData["IdEmisor"] = new SelectList(
                    _context.Emisores.Select(e => new
                    {
                        e.Id,
                        e.RazonSocial
                    }),
                    "Id",
                    "RazonSocial"
                );

                return View();
            }

            // POST: Facturas/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,IdCliente,IdEmisor,Fecha,TotalFactura")] Factura factura)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(factura);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["IdCliente"] = new SelectList(
                    _context.Clientes.Select(c => new
                    {
                        c.Id,
                        NombreCompleto = c.Nombres + " " + c.Apellidos
                    }),
                    "Id",
                    "NombreCompleto",
                    factura.IdCliente
                );

                ViewData["IdEmisor"] = new SelectList(
                    _context.Emisores.Select(e => new
                    {
                        e.Id,
                        e.RazonSocial
                    }),
                    "Id",
                    "RazonSocial",
                    factura.IdEmisor
                );

                return View(factura);
            }


        // GET: Facturas/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var factura = await _context.Facturas.FindAsync(id);
                if (factura == null)
                {
                    return NotFound();
                }

                ViewData["IdCliente"] = new SelectList(
                    _context.Clientes.Select(c => new
                    {
                        c.Id,
                        NombreCompleto = c.Nombres + " " + c.Apellidos
                    }),
                    "Id",
                    "NombreCompleto",
                    factura.IdCliente
                );

                ViewData["IdEmisor"] = new SelectList(
                    _context.Emisores.Select(e => new
                    {
                        e.Id,
                        e.RazonSocial
                    }),
                    "Id",
                    "RazonSocial",
                    factura.IdEmisor
                );

                return View(factura);
            }


        // POST: Facturas/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdEmisor,Fecha,TotalFactura")] Factura factura)
            {
                if (id != factura.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(factura);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FacturaExists(factura.Id))
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

                // 👇 Ajuste igual que en Create/Edit (GET)
                ViewData["IdCliente"] = new SelectList(
                    _context.Clientes.Select(c => new
                    {
                        c.Id,
                        NombreCompleto = c.Nombres + " " + c.Apellidos
                    }),
                    "Id",
                    "NombreCompleto",
                    factura.IdCliente
                );

                ViewData["IdEmisor"] = new SelectList(
                    _context.Emisores.Select(e => new
                    {
                        e.Id,
                        e.RazonSocial
                    }),
                    "Id",
                    "RazonSocial",
                    factura.IdEmisor
                );

                return View(factura);
}


        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Emisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.Id == id);
        }
    }
}
