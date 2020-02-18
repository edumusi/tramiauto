using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tramiauto.Common.Model.Response;

namespace tramiauto.App.ViewModels
{
    public class TramitesPageViewModel : ViewModelBase
    {
        private UsuarioResponse _usuario;
        private ObservableCollection<TramiteResponse> _tramites;
        public TramitesPageViewModel(INavigationService navigationServive): base (navigationServive)
        {
            Title = "Tramites";
        }

        public ObservableCollection<TramiteResponse> Tramites
        {
            get => _tramites;
            set => SetProperty(ref _tramites, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("usuario"))
               { _usuario  = parameters.GetValue<UsuarioResponse>("usuario");
                 Title     = $"Tramites de {_usuario.FullName}";
                 Tramites  = new ObservableCollection<TramiteResponse>(_usuario.TramitesResponse);
               }


        }
    }
}
