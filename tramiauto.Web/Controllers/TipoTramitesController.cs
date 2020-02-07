using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tramiauto.Web.Models;
using tramiauto.Web.Models.Entities;

namespace tramiauto.Web.Controllers
{
    public class TipoTramitesController : Controller
    {
        private readonly DataContext _context;

        public TipoTramitesController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoTramites
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTramites.ToListAsync());
        }

        // GET: TipoTramites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTramite = await _context.TipoTramites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTramite == null)
            {
                return NotFound();
            }

            return View(tipoTramite);
        }

        // GET: TipoTramites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTramites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Costo,TiempoOperacion")] TipoTramite tipoTramite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTramite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTramite);
        }

        // GET: TipoTramites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTramite = await _context.TipoTramites.FindAsync(id);
            if (tipoTramite == null)
            {
                return NotFound();
            }
            return View(tipoTramite);
        }

        // POST: TipoTramites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Costo,TiempoOperacion")] TipoTramite tipoTramite)
        {
            if (id != tipoTramite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTramite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTramiteExists(tipoTramite.Id))
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
            return View(tipoTramite);
        }

        // GET: TipoTramites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTramite = await _context.TipoTramites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTramite == null)
            {
                return NotFound();
            }

            return View(tipoTramite);
        }

        // POST: TipoTramites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTramite = await _context.TipoTramites.FindAsync(id);
            _context.TipoTramites.Remove(tipoTramite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTramiteExists(int id)
        {
            return _context.TipoTramites.Any(e => e.Id == id);
        }
    }
}
