using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tramiauto.Common.Model;

namespace tramiauto.Common.Services
{
    public interface IMenuService
    {        
        List<Menu> GenerateMenuWebAppRightHeader(bool IsAuthenticated, string name);

        List<Menu> GenerateMenuWebAppLeftHeader(bool IsAuthenticated, string rol, string sectionActive);
    }//Class

}//NameSpace