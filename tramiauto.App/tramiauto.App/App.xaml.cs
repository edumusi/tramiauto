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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ3NzIwQDMxMzgyZTMxMmUzMFQyOHpMV0k3Z2hkUnNBaGREVVo4dExaVWdJd0NzZTV2bFlkWUZMejBpRWs9");

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
