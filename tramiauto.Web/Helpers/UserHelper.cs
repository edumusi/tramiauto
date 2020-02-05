using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using tramiauto.Web.Models.Entities;



/*** 
 * Implementación del manejo de los usuarios, INYECCIÓN DE DEPENDENCIAS en el starup
 * ***/
namespace tramiauto.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserLogin>    _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(UserManager<UserLogin>    userManager,
                          RoleManager<IdentityRole> roleManager)
                        {
                            _userManager = userManager;
                            _roleManager = roleManager;
                        }

        public async Task<IdentityResult> AddUserAsync(UserLogin user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserLogin user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<UserLogin> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);            
        }

        public async Task<bool> IsUserInRoleAsync(UserLogin user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

    }//class
}//NameSpace
