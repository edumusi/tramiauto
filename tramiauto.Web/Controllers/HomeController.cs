using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tramiauto.Common;
using tramiauto.Common.Services;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;

namespace tramiauto.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;
        private readonly IUserHelper  _userHelper;

        public HomeController(ILogger<HomeController> logger, IUserHelper userHelper, IMenuService menuService)
        {
            _logger      = logger;
            _menuService = menuService;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            ViewBag.MenuLeft  = _menuService.GenerateMenuWebAppLeftHeader (User.Identity.IsAuthenticated, _userHelper.GetRol( (User.Identity as ClaimsIdentity) ).FirstOrDefault() );
            ViewBag.MenuRight = _menuService.GenerateMenuWebAppRightHeader(User.Identity.IsAuthenticated, User.Identity.Name);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            ViewBag.Message = MessageCenter.webAppMessagePageNotFound;
            return View();
        }

    }//Class
}//Namespace
