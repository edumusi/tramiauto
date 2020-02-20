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
using tramiauto.App.ViewModels.VM;

namespace tramiauto.App.ViewModels.Pages
{
    public class TramitesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UsuarioResponse _usuario;
        private ObservableCollection<TramiteItemViewModel> _tramites;
        public TramitesPageViewModel(INavigationService navigationService): base (navigationService)
        {
            _navigationService = navigationService;
            Title = MessageCenter.appTitlePageTramites;            
        }

        public ObservableCollection<TramiteItemViewModel> Tramites
        {
            get => _tramites;
            set => SetProperty(ref _tramites, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("usuario"))
               { 
                 _usuario  = parameters.GetValue<UsuarioResponse>("usuario");
                 Title     = _usuario.Rol== RoleTA.Usuario? $" Mis {MessageCenter.appTitlePageTramites}..." : $"{MessageCenter.appTitlePageTramites} de {_usuario.FullName}";
                //Tramites = new ObservableCollection<TramiteResponse>(_usuario.TramitesResponse);
                //TODO: Como es otra clase que se hereda, por el comando se necesita
                Tramites = new ObservableCollection<TramiteItemViewModel>( _usuario.TramitesResponse.Select(p => new TramiteItemViewModel(_navigationService) 
                                                                                                                                         { AdjuntosResponse = p.AdjuntosResponse
                                                                                                                                           , AutomotorResponse = p.AutomotorResponse
                                                                                                                                           , Costo = p.Costo
                                                                                                                                           , Descripcion = p.Descripcion
                                                                                                                                           , FechaEntrega = p.FechaEntrega
                                                                                                                                           , FechaRegistro = p.FechaRegistro 
                                                                                                                                           , Id = p.Id
                                                                                                                                           , Nombre = p.Nombre
                                                                                                                                           , Status = p.Status
                                                                                                                                           , TiempoEntrega = p.TiempoEntrega
                                                                                                                                           , TipoTramite = p.TipoTramite
                                                                                                                                          }
                                                                                                           ).ToList() );
               }


        }
    }
}
