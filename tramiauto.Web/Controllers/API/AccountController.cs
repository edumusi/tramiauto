using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;

namespace tramiauto.Web.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]    
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("GetUsuarioByEmail")]
        [HttpPost]
        public async Task<IActionResult> GetUserByEmailAsync([FromBody]EmailRequest request)        
        {
            if (!ModelState.IsValid)
               { return BadRequest(MessageErrorHelper.showModelStateError(ModelState)); }

            var usuario = await _dataContext.Usuarios.Include(c => c.Automotores  )
                                                     .Include(c => c.Tramites     )                                                     
                                                     .Include(c => c.DatosFiscales)
                                                     .FirstOrDefaultAsync( u =>u.UserLogin.NormalizedEmail == request.Email.ToUpper());
            if(usuario == null)
            {
                //ModelState.AddModelError(string.Empty, MessageCenter.labelEmailNotFound);
                return NotFound(request); 
            }

            return Ok();

        }//GetUsuarioByEmail



        [Route("GetUser")]
        [HttpGet]        
        //public async Task<IActionResult> GetUserByEmailAsync(EmailRequest request)
        public IActionResult GetUser(EmailRequest request)
        {
           
            return Ok();
        }

    }//Class Account
}//NameSpace