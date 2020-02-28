using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using tramiauto.Common;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model.Request;
using tramiauto.Common.Services;

namespace tramiauto.App.ViewModels.Pages
{
    public class LoginPageViewModel : ViewModelBase
    {
        /* Atributos Privados
* Constructor
* Atributos Publicos
* Metodos Publicos
* Metodos Privatos
*/
        private readonly INavigationService _navigationService;
        private readonly IApiService        _apiService;
        private string _password;
        private bool  _isRunning;
        private bool  _isEnabled;
        private DelegateCommand _loginCommand;
        public LoginPageViewModel( INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title       = MessageCenter.appTitlePageLogin;
            IsEnabled   = true;//Por defecto los bool son falsos

            _navigationService = navigationService;
            _apiService        = apiService;

            //TODO: (Quitar) las credenciasles por deafutl para no digitar
            Email    = "ems@convivere.casa";
            Password = "user123";
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

            var url     = MessageCenter.URL;
            var url_API = MessageCenter.URL_API; // TODO: usar App Resorse App.Current.Resources["UrlAPI"].ToString();
            var connect = await _apiService.CheckConnectivityAsync(url);
            if (!connect)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorConnect, MessageCenter.appLabelErrorNoInter, MessageCenter.appLabelAceptar);

                return;
            }

            var request   = new LoginTARequest { Email = Email, Password = Password };
            var respToken = await _apiService.GetTokenAsync(url_API, "Account", "CreateToken", request);

            if (!respToken.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                Password = string.Empty;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelError, MessageCenter.webApplabelLoginFail, MessageCenter.appLabelAceptar);

                return;
            }

            IsEnabled = true;
            IsRunning = false;

            var token    = respToken.Result;
            var respUser = await _apiService.GetUsuarioByEmailAsync(url_API, "Account", "GetUsuarioByEmail", "bearer", token.Token, Email);
            if (!respUser.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                Password  = string.Empty;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelError, MessageCenter.appLabelErrorNoUserToken, MessageCenter.appLabelAceptar);

                return;
            }

            var usuario      = respUser.Result;
            Settings.Usuario = JsonConvert.SerializeObject(usuario);
            Settings.Token   = JsonConvert.SerializeObject(token);

            await _navigationService.NavigateAsync("/TramiteMasterDetailPage/NavigationPage/TramitesPage");
            IsEnabled = true;
            IsRunning = false;
        }
    }
}
