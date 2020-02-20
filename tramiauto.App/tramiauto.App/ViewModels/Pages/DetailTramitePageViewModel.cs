using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tramiauto.Common.Model.Response;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Common;

namespace tramiauto.App.ViewModels.Pages
{
    public class DetailTramitePageViewModel : ViewModelBase
    {
        private TramiteResponse _tramite;

        public DetailTramitePageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = MessageCenter.appTitlePageDetailTramite;
        }

        public TramiteResponse Tramite
        {
            get => _tramite;
            set => SetProperty(ref _tramite, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("tramite"))
               { Tramite = parameters.GetValue<TramiteResponse>("tramite"); }

            Title = MessageCenter.appTitlePageDetailTramite + $"{Tramite.Nombre}";

        }

     }//CLASS
}//NameSpace
