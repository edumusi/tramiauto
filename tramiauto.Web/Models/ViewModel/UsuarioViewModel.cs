using System;
using tramiauto.Common;
using System.ComponentModel.DataAnnotations;
using tramiauto.Common.Model.Request;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace tramiauto.Web.Models.ViewModel
{
    public class UsuarioViewModel : NewUserRequest
    {
        
        public IEnumerable<SelectListItem> Roles { get; set; }

    }
}
