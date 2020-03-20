using Prism.Navigation;
using Syncfusion.XForms.DataForm;
using System;
using System.ComponentModel;
using tramiauto.App.Model;
using tramiauto.Common;
using Xamarin.Forms;

namespace tramiauto.App.ViewModels.Pages
{
    public class NuevoTramitePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private Command _newTramiteCommand;
        private Command _addDocsCommand;
        //private UsuarioResponse _usuario;
        public Tramite Tramite { get; set; }
        public bool IsVisibleButtonDoc { get; set; }

        public Command NewTramiteCommand => _newTramiteCommand ?? (_newTramiteCommand = new Command(NewTramite));

        public Command AddDocsCommand => _addDocsCommand ?? (_addDocsCommand = new Command(AddDocs));

        public NuevoTramitePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Title              = "Solicitar Tramite";
            IsVisibleButtonDoc = true;

            var tramite = new Tramite();
            tramite.PropertyChanged += Tramite_PropertyChanged;
            Tramite  = tramite;            
        }
        
        
        private void Tramite_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TipoTramite")
            {
                var item = sender as Tramite;
                Int32.TryParse(item.TipoTramite, out int x);
                Tramite.Monto = 800 * x;               
            }            
        }

        private async void NewTramite(object sender)
        {
            var dataForm  = sender as SfDataForm;            
            bool isValidDF = dataForm.Validate();
            dataForm.CollapseGroup(MessageCenter.appGroupName1DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName2DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName3DFTramite);
            
            await App.Current.MainPage.DisplayAlert("NewTramite", $"NewTramite Model: {isValidDF} / {Tramite.TipoTramite} - {Tramite.Verificacion} - {Tramite.TipoPago} - {Tramite.Monto}", MessageCenter.appLabelAceptar);
            
            //await _navigationService.NavigateAsync("/TramiteMasterDetailPage/NavigationPage/NuevoTramitePage");
        }

        private async void AddDocs(object sender)
        {            
         //   await App.Current.MainPage.DisplayAlert("AddDocs", $"AddDocsl: {Tramite.TipoTramite} - {Tramite.Verificacion} - {Tramite.TipoPago} - {Tramite.Monto}", MessageCenter.appLabelAceptar);

            var paramTramite = new NavigationParameters { { "tramite", Tramite } };
            await _navigationService.NavigateAsync("DocsPage", paramTramite);
            //await _navigationService.NavigateAsync("/TramiteMasterDetailPage/NavigationPage/DocsPage");
        }


    }//Class       
}//Namespace
