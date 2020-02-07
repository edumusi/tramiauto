using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model;
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
        //public async Task<IActionResult> GetUserByEmailAsync(EmailRequest request)
            public IActionResult GetUserByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid )
               { return BadRequest(); }
/*
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync( u => u.Correo.ToUpper() == request.Email.ToUpper() );

            if(usuario == null)
              { return NotFound(); }

            return Ok(usuario);
*/
return Ok();
        }

        [Route("GetUser")]
        [HttpGet]        
        //public async Task<IActionResult> GetUserByEmailAsync(EmailRequest request)
        public IActionResult GetUser(EmailRequest request)
        {
           
            return Ok();
        }

    }//Class Account
}//NameSpace