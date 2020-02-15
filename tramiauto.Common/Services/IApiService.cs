using System.Threading.Tasks;
using tramiauto.Common.Model;

namespace tramiauto.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, LoginTARequest request);
        Task<Response> GetUsuarioByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, string email);
    }
}