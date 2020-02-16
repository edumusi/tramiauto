using System.Threading.Tasks;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Model.Response;

namespace tramiauto.Common.Services
{
    public interface IApiService
    {
        Task<ResponseAPI<TokenResponse>> GetTokenAsync(string urlBase, string servicePrefix, string controller, LoginTARequest request);
        Task<ResponseAPI<UsuarioResponse>> GetUsuarioByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, string email);
    }
}