using tramiauto.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tramiauto.Common;
using tramiauto.Common.Model.Request;
using tramiauto.Web.Models.ViewModel;
using tramiauto.Common.Model.Response;
using tramiauto.Web.Models;
using tramiauto.Web.Models.Entities;

namespace tramiauto.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper   _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext   _dataContext;

        public AccountController(IUserHelper userHelper, ICombosHelper combosHelper, DataContext context)
        {
            _userHelper   = userHelper;
            _combosHelper = combosHelper;
            _dataContext  = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
               { return RedirectToAction("Index", "Home");  }

            return View();
        }

        public IActionResult NotAuthorized()
        {
            ViewBag.Message = MessageCenter.webAppMessageNotAuthorized;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginTARequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                       { return Redirect(Request.Query["ReturnUrl"].First()); }
                    
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, MessageCenter.webApplabelLoginFail);
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            var view = (User.Identity.IsAuthenticated) ? new UsuarioViewModel { Roles = _combosHelper.GetComboRoles() } : new UsuarioViewModel { Roles = _combosHelper.GetComboRolUser() };

            ViewBag.Message = MessageCenter.webAppTitlePageRegisterUser;
            return View(view);
        }


        [HttpPost]       
        public async Task<IActionResult> Register(UsuarioViewModel view)
        {
            if (ModelState.IsValid)
            {
                var rol  = _combosHelper.GetComboRoles().Where(r => r.Value == view.RoleId.ToString()).Select(r => r.Text);
                view.Rol = rol.FirstOrDefault().ToString();

                var addUserResult = await _userHelper.AddUsuario(view);                
                if (addUserResult == IdentityResult.Success)                
                    { 
                    var userLogin = await _userHelper.GetUserByEmailAsync(view.Correo);
                    await _dataContext.Usuarios.AddAsync(new Usuario {  Automotores = null, DatosFiscales = null, FirstName = view.FirstName, LastName= view.LastName, Tramites =null, UserLogin = userLogin });
                    await _dataContext.SaveChangesAsync();
                    //ToDo: implementar el guardado en sesión del TOKEN
                    //TokenResponse token = _userHelper.BuildToken(new LoginTARequest { Email = view.Correo, Password = view.Password, RememberMe = false });                    
                    var result = await _userHelper.LoginAsync(new LoginTARequest { Email =view.Correo, Password = view.Password, RememberMe= false });
                    if (result.Succeeded)
                       { return RedirectToAction("Index", "Home"); }
                    
                    }
                
                ModelState.AddModelError(string.Empty, MessageErrorHelper.showIdentityResultError(addUserResult) );
                view.Rol = rol.FirstOrDefault().ToString();
                return View(view);

            }

            return View(view);
        }

        //TODO: arreglar la vista para tener dos vistar parciales /In PartailView //PartailView.cshtml https://stackoverflow.com/questions/5410055/using-ajax-beginform-with-asp-net-mvc-3-razor
        public async Task<IActionResult> ChangeUser()
        {
            if ( !User.Identity.IsAuthenticated )
               { return RedirectToAction("Login", "Account"); }

            var user = await _userHelper.GetUsuarioTAByEmailAsync(User.Identity.Name);
            if (user == null)
               { return NotFound(); }

            var view = new EditUserViewModel{ FirstName = user.FirstName,
                                              LastName  = user.LastName,
                                              CellPhone = user.CellPhone
                                            };
            ViewBag.Message = MessageCenter.webAppTitlePageEditUser ;
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userHelper.GetUsuarioTAByEmailAsync(User.Identity.Name);
                usuario.FirstName = view.FirstName;
                usuario.LastName  = view.LastName;
                usuario.UserLogin.PhoneNumber = view.CellPhone;
                usuario.UserLogin.PhoneNumberConfirmed = false;

                _userHelper.UpdateUsuarioTAB(usuario);

                return RedirectToAction("Index", "Home");
            }

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userHelper.GetUsuarioTAByEmailAsync(User.Identity.Name);
                var result  = await _userHelper.ChangePasswordAsync(usuario.UserLogin, view.OldPassword, view.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction("ChangeUser");

               ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description); 
                
            }

            return View(view);
        }


    }//Class
}//NameSpace