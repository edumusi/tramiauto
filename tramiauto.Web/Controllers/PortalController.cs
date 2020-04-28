using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tramiauto.Common.Services;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;
using Microsoft.AspNetCore.Mvc;
using tramiauto.Common.Model;

namespace tramiauto.Web.Controllers
{
    public class PortalController : Controller
    {
        private readonly IUserHelper   _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IMailHelper   _mailHelper;
        private readonly IMenuService  _menuService;
        private readonly DataContext   _dataContext;

        public PortalController(IUserHelper userHelper, ICombosHelper combosHelper, IMailHelper mailHelper, IMenuService menuService, DataContext context)
        {
            _userHelper   = userHelper;
            _combosHelper = combosHelper;
            _mailHelper   = mailHelper;
            _menuService  = menuService;
            _dataContext  = context;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            { return RedirectToAction("Login", "Account"); }

            ViewBag.MenuLeft    = _menuService.GenerateMenuWebAppLeftHeader(User.Identity.IsAuthenticated, _userHelper.GetRol((User.Identity as ClaimsIdentity)).FirstOrDefault(), "HomePrice");
            ViewBag.MenuRight   = _menuService.GenerateMenuWebAppRightHeader(User.Identity.IsAuthenticated, User.Identity.Name);
            ViewBag.headerClass = "Portal";

            spacingModel modelValue = new spacingModel { CellSpacing = new double[] { 10, 10 } };

            return View(modelValue);            
        }
    }
}