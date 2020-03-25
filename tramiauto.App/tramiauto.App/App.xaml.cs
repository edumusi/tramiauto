using Openpay.Xamarin;
using Prism;
using Prism.Ioc;
using tramiauto.App.ViewModels.Pages;
using tramiauto.App.Views;
using tramiauto.Common.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace tramiauto.App
{
    public partial class App
    {
        private const string OPENPAY_ID         = "murhuosyqouvqptjzlkr";
        private const string OPENPAY_PUBLIC_KEY = "pk_79e455b48c0341da8a0aa7fd959af813";

        public App() : this(null) { }        

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1OTgxQDMxMzcyZTM0MmUzMG0yV2tIWEFhSitrRmYzczdsYXRKSlRIRGdKd0hKSUtETklQZ0hXWGFtQkU9;MjE1OTgyQDMxMzcyZTM0MmUzMEJibzg3RE9NcFVtQklGZWU0SVhoSWFjZG9PMEZLV3ZRTGxuSUFQYTRJSTg9;MjE1OTgzQDMxMzcyZTM0MmUzMFYyMzBmYWNHR1RWQUxadC9Xa29FSi9Fa3NpL29CWm5DRUQ3aVZwOVlxSm89;MjE1OTg0QDMxMzcyZTM0MmUzMFNkWDRtL01iUnJ3VGFJc2Q0L291aGNKZjUyaS9KblY5ZjFHNVU5MnJEMFE9;MjE1OTg1QDMxMzcyZTM0MmUzME55Ylk2dEQwWERnQ3BtRXhQT3Q5Tk4rUlVXd2dmL3pBZWsyVWwxUmNSQWc9");
            if ( CrossOpenpay.IsSupported )
               { CrossOpenpay.Current.Initialize(OPENPAY_ID, OPENPAY_PUBLIC_KEY, false); }

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            
            containerRegistry.RegisterForNavigation<LoginPage              , LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<TramitesPage           , TramitesPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage                , MapPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage         , ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailTramitePage      , DetailTramitePageViewModel>();
            containerRegistry.RegisterForNavigation<TramiteMasterDetailPage, TramiteMasterDetailPageViewModel>();            
            containerRegistry.RegisterForNavigation<NuevoTramitePage       , NuevoTramitePageViewModel>();
            containerRegistry.RegisterForNavigation<DocsPage               , DocsPageViewModel>();
        }
    }//Class
}//Namespace
