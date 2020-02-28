using tramiauto.Common.Model;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tramiauto.Common.Services;
using Newtonsoft.Json;
using tramiauto.Common.Model.Response;
using tramiauto.Common.Helpers;

namespace tramiauto.App.ViewModels.Pages
{
    public class TramiteMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _usuarioName;

        public TramiteMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;            
            LoadMenus();
        }
        
        public string UsuarioName
        {
            get { return _usuarioName; }
            set { SetProperty(ref _usuarioName, value); }
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }//para actualizar la interfaz

        private void LoadMenus()
        {
            var usuario = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);
            UsuarioName = usuario.FullName;
            var menus   = MenuService.GenerateMenuApp(null);

            Menus = new ObservableCollection<MenuItemViewModel>(
                        menus.Select(m => new MenuItemViewModel(_navigationService)
                                    {   Icon     = m.Icon,
                                        PageName = m.PageName,
                                        Title    = m.Title
                                    }).ToList());
        }

    }//Class
}//Namesapce
