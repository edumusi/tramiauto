using Prism.Navigation;

namespace tramiauto.App.ViewModels.Pages
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Modify User";
        }
    }//Class
}//Namespace

