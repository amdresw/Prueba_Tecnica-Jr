using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturacionMVC.Models;

namespace FacturacionMVC.Controllers
{
    public class EmisoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmisoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emisores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emisores.ToListAsync());
        }

        // GET: Emisores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emisor = await _context.Emisores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emisor == null)
            {
                return NotFound();
            }

            return View(emisor);
        }

        // GET: Emisores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emisores/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identificacion,RazonSocial,Telefono,Email,Direccion")] Emisor emisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emisor);
        }

        // GET: Emisores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emisor = await _context.Emisores.FindAsync(id);
            if (emisor == null)
            {
                return NotFound();
            }
            return View(emisor);
        }

        // POST: Emisores/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificacion,RazonSocial,Telefono,Email,Direccion")] Emisor emisor)
        {
            if (id != emisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmisorExists(emisor.Id))
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
            return View(emisor);
        }

        // GET: Emisores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emisor = await _context.Emisores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emisor == null)
            {
                return NotFound();
            }

            return View(emisor);
        }

        // POST: Emisores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emisor = await _context.Emisores.FindAsync(id);
            if (emisor != null)
            {
                _context.Emisores.Remove(emisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmisorExists(int id)
        {
            return _context.Emisores.Any(e => e.Id == id);
        }
    }
}
