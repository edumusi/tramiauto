using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Common.Services;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;

namespace tramiauto.Web.Controllers
{
    public class TramitesController : Controller
    {
        private readonly DataContext  _dataContext;
        private readonly IMenuService _menuService;
        private readonly IUserHelper  _userHelper;

        public TramitesController(DataContext context, IUserHelper userHelper, IMenuService menuService)
        {
            _dataContext = context;
            _menuService = menuService;
            _userHelper = userHelper;
        }

        //    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.MenuLeft = _menuService.GenerateMenuWebAppLeftHeader(User.Identity.IsAuthenticated, _userHelper.GetRol((User.Identity as ClaimsIdentity)).FirstOrDefault());
            ViewBag.MenuRight = _menuService.GenerateMenuWebAppRightHeader(User.Identity.IsAuthenticated, User.Identity.Name);

            return View( await _dataContext.Tramites.ToListAsync() );
        }

        // GET: Tramites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
               { return NotFound(); }

            var tramite = await _dataContext.Tramites.FirstOrDefaultAsync(m => m.Id == id);
            if (tramite == null)
               { return NotFound(); }

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
                _dataContext.Add(tramite);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tramite);
        }

        // GET: Tramites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
               { return NotFound(); }

            var tramite = await _dataContext.Tramites.FindAsync(id);
            if (tramite == null)
               { return NotFound(); }

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
                    _dataContext.Update(tramite);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TramiteExists(tramite.Id))
                       { return NotFound(); }
                    else
                       { throw; }
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

            var tramite = await _dataContext.Tramites
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
            var tramite = await _dataContext.Tramites.FindAsync(id);
            _dataContext.Tramites.Remove(tramite);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TramiteExists(int id)
        {
            return _dataContext.Tramites.Any(e => e.Id == id);
        }
    }
}
