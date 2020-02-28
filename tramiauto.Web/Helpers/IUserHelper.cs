using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Model.Response;
using tramiauto.Web.Models.Entities;
using tramiauto.Web.Models.ViewModel;


/*** 
 * Interfaz para el manejo de los usuarios, INYECCIÓN DE DEPENDENCIAS en el starup
 * ***/
namespace tramiauto.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserLogin> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserLogin user, string password);
        Task<IdentityResult> UpdateUserAsync(UserLogin user);

        Task CheckRoleAsync(string roleName);

        List<string> GetRol(ClaimsIdentity identity);

        Task AddUserToRoleAsync(UserLogin user, string roleName);

        Task<bool> IsUserInRoleAsync(UserLogin user, string roleName);

        Task<IList<string>> GetRolesByUserAsync(UserLogin user);

        Task<SignInResult> LoginAsync(LoginTARequest model);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(UserLogin user, string password);

        Task<IdentityResult> AddUsuario(UsuarioViewModel view);

        TokenResponse BuildToken(LoginTARequest userInfo);

        Task<IdentityResult> ChangePasswordAsync(UserLogin user, string oldPassword, string newPassword);

        Task<Usuario> GetUsuarioTAByEmailAsync(string email);

        void UpdateUsuarioTAB(Usuario usuario);



        Task<string> GenerateEmailConfirmationTokenAsync(UserLogin user);

        Task<IdentityResult> ConfirmEmailAsync(UserLogin user, string token);

        Task<UserLogin> GetUserByIdAsync(string userId);



        Task<string> GeneratePasswordResetTokenAsync(UserLogin user);

        Task<IdentityResult> ResetPasswordAsync(UserLogin user, string token, string password);


    }//Class
}//Namespace
