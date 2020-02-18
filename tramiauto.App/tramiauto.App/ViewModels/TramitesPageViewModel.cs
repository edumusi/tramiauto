using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using tramiauto.Common.Model.Response;

namespace tramiauto.App.ViewModels
{
    public class TramitesPageViewModel : ViewModelBase
    {
        private UsuarioResponse _usuario;
        public TramitesPageViewModel(INavigationService navigationServive): base (navigationServive)
        {
            Title = "Tramites";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("usuario"))
               { _usuario = parameters.GetValue<UsuarioResponse>("usuario");
                 Title    = $"Tramites de {_usuario.FullName}";
               }


        }
    }
}
