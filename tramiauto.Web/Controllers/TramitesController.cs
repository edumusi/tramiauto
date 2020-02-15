using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Web.Models;

namespace tramiauto.Web.Controllers
{
    public class TramitesController : Controller
    {
        private readonly DataContext _context;

        public TramitesController(DataContext context)
        {
            _context = context;
        }

        // GET: Tramites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tramites.ToListAsync());
        }

        // GET: Tramites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramite = await _context.Tramites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tramite == null)
            {
                return NotFound();
            }

            return View(tramite);
        }

        // GET: Tramites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tramites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Costo,TiempoEntrega,FechaEntrega,FechaRegistro,Status")] Tramite tramite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tramite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tramite);
        }

        // GET: Tramites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramite = await _context.Tramites.FindAsync(id);
            if (tramite == null)
            {
                return NotFound();
            }
            return View(tramite);
        }

        // POST: Tramites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Costo,TiempoEntrega,FechaEntrega,FechaRegistro,Status")] Tramite tramite)
        {
            if (id != tramite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tramite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TramiteExists(tramite.Id))
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
            return View(tramite);
        }

        // GET: Tramites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tramite = await _context.Tramites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tramite == null)
            {
                return NotFound();
            }

            return View(tramite);
        }

        // POST: Tramites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tramite = await _context.Tramites.FindAsync(id);
            _context.Tramites.Remove(tramite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TramiteExists(int id)
        {
            return _context.Tramites.Any(e => e.Id == id);
        }
    }
}
