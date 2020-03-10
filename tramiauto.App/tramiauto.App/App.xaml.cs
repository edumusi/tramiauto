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
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }        

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1OTgxQDMxMzcyZTM0MmUzMG0yV2tIWEFhSitrRmYzczdsYXRKSlRIRGdKd0hKSUtETklQZ0hXWGFtQkU9;MjE1OTgyQDMxMzcyZTM0MmUzMEJibzg3RE9NcFVtQklGZWU0SVhoSWFjZG9PMEZLV3ZRTGxuSUFQYTRJSTg9;MjE1OTgzQDMxMzcyZTM0MmUzMFYyMzBmYWNHR1RWQUxadC9Xa29FSi9Fa3NpL29CWm5DRUQ3aVZwOVlxSm89;MjE1OTg0QDMxMzcyZTM0MmUzMFNkWDRtL01iUnJ3VGFJc2Q0L291aGNKZjUyaS9KblY5ZjFHNVU5MnJEMFE9;MjE1OTg1QDMxMzcyZTM0MmUzME55Ylk2dEQwWERnQ3BtRXhQT3Q5Tk4rUlVXd2dmL3pBZWsyVWwxUmNSQWc9");

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
