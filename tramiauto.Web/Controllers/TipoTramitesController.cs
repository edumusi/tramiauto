using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Common.Services;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;

namespace tramiauto.Web.Controllers
{
    public class TipoTramitesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMenuService _menuService;
        private readonly IUserHelper  _userHelper;

        public TipoTramitesController(DataContext context, IUserHelper userHelper, IMenuService menuService)
        {
            _dataContext = context;
            _menuService = menuService;
            _userHelper = userHelper;
        }

        // GET: TipoTramites
        public async Task<IActionResult> Index()
        {
            ViewBag.MenuLeft  = _menuService.GenerateMenuWebAppLeftHeader(User.Identity.IsAuthenticated, _userHelper.GetRol((User.Identity as ClaimsIdentity)).FirstOrDefault(),"TipoTramitesIndex");
            ViewBag.MenuRight = _menuService.GenerateMenuWebAppRightHeader(User.Identity.IsAuthenticated, User.Identity.Name);            


            return View(await _dataContext.TipoTramites.ToListAsync());
        }

        // GET: TipoTramites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTramite = await _dataContext.TipoTramites
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
                _dataContext.Add(tipoTramite);
                await _dataContext.SaveChangesAsync();
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

            var tipoTramite = await _dataContext.TipoTramites.FindAsync(id);
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
                    _dataContext.Update(tipoTramite);
                    await _dataContext.SaveChangesAsync();
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

            var tipoTramite = await _dataContext.TipoTramites
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
            var tipoTramite = await _dataContext.TipoTramites.FindAsync(id);
            _dataContext.TipoTramites.Remove(tipoTramite);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTramiteExists(int id)
        {
            return _dataContext.TipoTramites.Any(e => e.Id == id);
        }
    }
}
