using Prism.Commands;
using Prism.Navigation;
using tramiauto.Common;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Services;

namespace tramiauto.App.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        /* Atributos Privados
* Constructor
* Atributos Publicos
* Metodos Publicos
* Metodos Privatos
*/
        private readonly IApiService _apiService;
        private string _password;
        private bool  _isRunning;
        private bool  _isEnabled;
        private DelegateCommand _loginCommand;
        public LoginPageViewModel( INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title       = "Ingreso a Tramiauto";
            IsEnabled   = true;//Por defecto los bool son falsos
            _apiService = apiService;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));
        

        public string Email { get; set; }

        public string Password 
        {  
           get => _password;
           set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
                { await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelError, MessageCenter.appTextEmailFieldRequired, MessageCenter.appLabelAceptar);
                  return;
                }

            if (string.IsNullOrEmpty(Password))
               { await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelError, MessageCenter.appTextPassFieldRequired, MessageCenter.appLabelAceptar);
                return;
               }

            IsRunning = true;
            IsEnabled = false;

            var url      = MessageCenter.URL_API; // TODO usar App Resorse App.Current.Resources["UrlAPI"].ToString();
            var request  = new LoginTARequest { Email = Email, Password = Password };
            var response = await _apiService.GetTokenAsync(url, "Account", "CreateToken", request);

            if (!response.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                Password  = string.Empty;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelError, MessageCenter.webApplabelLoginFail, MessageCenter.appLabelAceptar);
                
                return;
            }

            IsEnabled = true;
            IsRunning = false;

            await App.Current.MainPage.DisplayAlert("Ok", "We are making progress!", "Accept");

        }
    }
}
