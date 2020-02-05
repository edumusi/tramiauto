using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tramiauto.Web.Models.Entities;

/*** 
 * Interfaz para el manejo de los usuarios, INYECCIÓN DE DEPENDENCIAS en el starup
 * ***/
namespace tramiauto.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserLogin> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserLogin user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserLogin user, string roleName);

        Task<bool> IsUserInRoleAsync(UserLogin user, string roleName);

    }//Class
}//Namespace
