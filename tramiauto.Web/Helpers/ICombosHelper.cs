
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace tramiauto.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboStatusTA();

        IEnumerable<SelectListItem> GetComboTipoTramites();

        IEnumerable<SelectListItem> GetComboRoles();

        IEnumerable<SelectListItem> GetComboRolUser();

    }//Class
}//Namespace
