using Prism.Navigation;

namespace tramiauto.App.ViewModels.Pages
{
    public class MapPageViewModel : ViewModelBase
	{

        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Map";
        }
    }//Clase

}//Namespace
