using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Model.Response;

namespace tramiauto.Common.Services
{
    public class ApiService : IApiService
    {
        public async Task<ResponseAPI> GetTokenAsync(string urlBase,
                                                  string controller, 
                                                  string method,
                                                  LoginTARequest request)
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(request); //LLamada por PostMAN
                var content       = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client        = new HttpClient { BaseAddress = new Uri(urlBase) };
                var url           = $"{controller}/{method}";

                var response = await client.PostAsync(url, content); //Consumo de Servicio por metodo POST
                var result   = await response.Content.ReadAsStringAsync();// Respuesta de la llamada API

                if (!response.IsSuccessStatusCode) //Si regreso un BAd request
                { return new ResponseAPI { IsSuccess = false, Message = result }; }

                var token = JsonConvert.DeserializeObject<TokenResponse>(result);

                return new ResponseAPI { IsSuccess = true, Result = token };
            }
            catch (Exception ex)
            { return new ResponseAPI { IsSuccess = false, Message = ex.Message }; }
        }

        public async Task<ResponseAPI> GetUsuarioByEmail(string urlBase,
                                                      string servicePrefix,
                                                      string controller,
                                                      string tokenType,
                                                      string accessToken,
                                                      string email)
        {
            try
            {
                var request = new EmailRequest { Email = email };
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient { BaseAddress = new Uri(urlBase) };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                { return new ResponseAPI { IsSuccess = false, Message = result }; }

                var owner = JsonConvert.DeserializeObject<UsuarioResponse>(result);

                return new ResponseAPI { IsSuccess = true, Result = owner };

            }
            catch (Exception ex)
            { return new ResponseAPI { IsSuccess = false, Message = ex.Message }; }

        }
    }//CLASS
}//NAMESACE
