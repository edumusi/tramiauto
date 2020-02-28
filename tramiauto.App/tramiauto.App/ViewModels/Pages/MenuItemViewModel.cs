using System;
using Prism.Commands;
using Prism.Navigation;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model;

namespace tramiauto.App.ViewModels.Pages
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        private async void SelectMenu()
        {
            if (PageName.Equals("LoginPage"))
            {
                Settings.Usuario = null;
                Settings.Token   = null;
                await _navigationService.NavigateAsync("/NavigationPage/LoginPage"); //La primera diagonal rompe el patron de navegacion es decir es la unica pagina no entra en menu
                return;
            }

            await _navigationService.NavigateAsync($"/TramiteMasterDetailPage/NavigationPage/{PageName}");

        }
    }
}
