using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;
using tramiauto.Web.Models.Entities;
using tramiauto.Common;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Model.Response;
using tramiauto.Common.Model.DataEntity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using tramiauto.Web.Models.ViewModel;



namespace tramiauto.Web.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
    private readonly DataContext    _dataContext;
    private readonly IConfiguration _configuration;
    private readonly IUserHelper    _userHelper;
    private readonly IMailHelper    _mailHelper;
    private readonly ICombosHelper  _combosHelper;

    public AccountController(DataContext dataContext, IConfiguration configuration, IUserHelper userHelper, IMailHelper mailHelper, ICombosHelper combosHelper)
    {
        _dataContext   = dataContext;
        _configuration = configuration;
        _userHelper    = userHelper;
        _mailHelper    = mailHelper;
        _combosHelper  = combosHelper;
    }

    [Route("CreateToken")]
    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] LoginTARequest model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.Email);
                if (user == null)
                   {    return NotFound(MessageCenter.webApplabelEmailNotFound + " " + model.Email);  }
                else
                    {
                        var result = await _userHelper.ValidatePasswordAsync(user, model.Password);

                        if (result.Succeeded)
                           { return Created(string.Empty, _userHelper.BuildToken(model)); }
                        else
                           { return BadRequest(MessageCenter.webApplabelLoginFail);       }
                    }
        }

        return BadRequest();
    }

    

    [Route("GetUsuarioByEmail")]
    [HttpPost]
    public async Task<IActionResult> GetUserByEmailAsync([FromBody]EmailRequest request)
    {
        if (!ModelState.IsValid)
           { return BadRequest(MessageErrorHelper.showModelStateError(ModelState)); }
            
        var usuario = await _dataContext.Usuarios.Include(c => c.UserLogin)
                                                    .Include(c => c.Automotores)
                                                    .Include(c => c.Tramites).ThenInclude(a => a.Adjuntos)
                                                    .Include(c => c.Tramites).ThenInclude(t => t.TipoTramite)
                                                    .Include(c => c.DatosFiscales)
                                                    .FirstOrDefaultAsync(u => u.UserLogin.NormalizedEmail == request.Email.ToUpper());
        if (usuario == null)
        {//ModelState.AddModelError(string.Empty, MessageCenter.labelEmailNotFound);
            return NotFound(request);
        }

        return Ok(ToUsuarioResponse(usuario));

    }//GetUsuarioByEmail

    // ******************************APP ******************************************/
    [Route("RegisterUser")]
    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync([FromBody] NewUserRequest request)
    {
        if (!ModelState.IsValid)
           { return BadRequest(new Resp<object>{ IsSuccess = false, Message = MessageErrorHelper.showModelStateError(ModelState) }); }

        var user  = await _userHelper.GetUserByEmailAsync(request.Correo);
        if (user != null)
           { return BadRequest(new Resp<object> { IsSuccess = false, Message = MessageCenter.appTextEmailUsed }); }

        var newUser = new UsuarioViewModel { Correo    = request.Correo
                                            , CellPhone = request.CellPhone
                                            , FirstName = request.FirstName
                                            , LastName  = request.LastName
                                            , RoleId    = request.RoleId
                                            , Rol       = _combosHelper.GetComboRolesByValue(request.RoleId.ToString())
                                            , Password  = request.Password                                               
                                            , PasswordConfirm = request.PasswordConfirm                                               
                                            };

        var addUserResult  = await _userHelper.AddUsuario(newUser);         
        if (addUserResult != IdentityResult.Success)
           { return BadRequest(new Resp<object> { IsSuccess = false, Message = MessageErrorHelper.showIdentityResultError(addUserResult) }); }       

        var userLogin = await _userHelper.GetUserByEmailAsync(request.Correo);
        var myToken   = await _userHelper.GenerateEmailConfirmationTokenAsync(userLogin);
        var tokenLink = Url.Action("ConfirmEmail", "Account", new { userid = userLogin.Id,
                                                                    token  = myToken
                                                                  }, protocol: HttpContext.Request.Scheme);
            
        _mailHelper.SendEmailAccountConfirmation(request.Correo, tokenLink);
        
        return Ok(new Resp<object>{ IsSuccess = true, Message = MessageCenter.commonMessageEmailInst });

    }    

    [HttpPost]
    [Route("RecoverPassword")]
    public async Task<IActionResult> RecoverPassword([FromBody] EmailRequest request)
    {
	    if (!ModelState.IsValid)
	       { return BadRequest(new Resp<object> { IsSuccess = false, Message = "Bad request" }); }

	    var user = await _userHelper.GetUserByEmailAsync(request.Email);
	    if (user == null)
	       { return BadRequest(new Resp<object> { IsSuccess = false, Message = MessageCenter.commonMessageRecoverNoEmail }); }

	    var myToken   = await _userHelper.GeneratePasswordResetTokenAsync(user);
	    var tokenLink = Url.Action("ResetPassword", "Account", new { token = myToken }, protocol: HttpContext.Request.Scheme);
        _mailHelper.SendEmailRecoverPwd(request.Email, tokenLink);
            
	    return Ok(new Resp<object> { IsSuccess = true, Message = MessageCenter.commonMessageRecoverEmail });
    }



    // ******************************APP ******************************************/





    private UsuarioResponse ToUsuarioResponse(Usuario usuario)
    {
    return new UsuarioResponse
                { Id           = usuario.Id
                , FirstName  = usuario.FirstName
                , LastName   = usuario.LastName
                , FixedPhone = usuario.FixedPhone
                , CellPhone  = usuario.UserLogin?.PhoneNumber
                , Correo     = usuario.UserLogin?.Email                    

                , AutomotorResponses = usuario.Automotores?.Select(a => new AutomotorResponse
                                                                                { Id           = a.Id
                                                                                , NumeroMotor = a.NumeroMotor
                                                                                , NumeroSerie = a.NumeroSerie
                                                                                , Marca       = a.Marca
                                                                                , Modelo      = a.Modelo
                                                                                , Tipo        = a.Tipo
                                                                                }).ToList()
                , TramitesResponse = usuario.Tramites?.Select(t => new TramiteResponse
                                                                        {    Id = t.Id
                                                                            , Nombre        = t.Nombre
                                                                            , Descripcion   = t.Descripcion
                                                                            , Costo         = t.Costo
                                                                            , TiempoEntrega = t.TiempoEntrega
                                                                            , FechaEntrega  = t.FechaEntrega
                                                                            , FechaRegistro = t.FechaRegistro
                                                                            , Status        = t.Status.Nombre
                                                                            , TipoTramite   = ToTipoTramiteResponsee(t.TipoTramite)
                                                                            , AdjuntosResponse = t.Adjuntos?.Select(a => new TramiteAdjuntosResponse { Id   = a.Id
                                                                                                                                                    , Tipo = a.Tipo
                                                                                                                                                    , Ruta = a.Ruta
                                                                                                                    }).ToList()
                                                                }).ToList()
                , DatosFiscalesResponse = ToDatosFiscalesResponse(usuario.DatosFiscales)
        };
    }
        
    private TipoTramiteResponse ToTipoTramiteResponsee(TipoTramite TipoTramite)
    {
        if (TipoTramite == null)
            return new TipoTramiteResponse();
        else
            return new TipoTramiteResponse { Id               = TipoTramite.Id
                                            , Nombre          = TipoTramite.Nombre
                                            , Descripcion     = TipoTramite.Descripcion
                                            , Costo           = TipoTramite.Costo
                                            , TiempoOperacion = TipoTramite.TiempoOperacion
            };

    }
    
    private DatosFiscalesResponse ToDatosFiscalesResponse(DatosFiscales DatosFiscales)
    {
        if (DatosFiscales == null)
            return new DatosFiscalesResponse();
        else
            return new DatosFiscalesResponse{Rfc               = DatosFiscales.Rfc
                                            ,Calle             = DatosFiscales.Calle
                                            ,NumeroExterior    = DatosFiscales.NumeroExterior
                                            ,NumeroInterior    = DatosFiscales.NumeroInterior
                                            ,Colonia           = DatosFiscales.Colonia
                                            ,AlcaldiaMunicipio = DatosFiscales.AlcaldiaMunicipio
                                            ,Estado            = DatosFiscales.Estado
                                            ,CodigoPostal      = DatosFiscales.CodigoPostal
                                            };
    }
       

    }//Class Account
}//NameSpace