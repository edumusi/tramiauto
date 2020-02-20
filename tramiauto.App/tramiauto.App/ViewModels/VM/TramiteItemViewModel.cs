using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using tramiauto.Common.Model.Response;

namespace tramiauto.App.ViewModels.VM
{
    public class TramiteItemViewModel: TramiteResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTramiteCommand;

        public TramiteItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectTramiteCommand => _selectTramiteCommand ?? (_selectTramiteCommand = new DelegateCommand(SelectTramite));

        private async void SelectTramite()
        {
             var paramTramite = new NavigationParameters { { "tramite", this } };
            await _navigationService.NavigateAsync("DetailTramitePage", paramTramite);
        }

    }//Class
}//NameSpace
