using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using tramiauto.Common.Model;
using tramiauto.Web.Models.Entities;



/*** 
 * Implementación del manejo de los usuarios, INYECCIÓN DE DEPENDENCIAS en el starup
 * ***/
namespace tramiauto.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserLogin>  _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserLogin> _signInManager;

        public UserHelper(UserManager<UserLogin>     userManager
                         , RoleManager<IdentityRole> roleManager
                         , SignInManager<UserLogin>  signInManager)
                        {
                            _userManager   = userManager;
                            _roleManager   = roleManager;
                            _signInManager = signInManager;
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

        public async Task<SignInResult> LoginAsync(LoginTARequest model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> ValidatePasswordAsync(UserLogin user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

    }//class
}//NameSpace
