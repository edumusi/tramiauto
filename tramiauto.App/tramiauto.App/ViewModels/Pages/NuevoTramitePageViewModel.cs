using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using tramiauto.App.Model;
using tramiauto.Common;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model.Response;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;
using FormaDepago = tramiauto.Common.Model.DataEntity.FormaDePago;

namespace tramiauto.App.ViewModels.Pages
{
    public class NuevoTramitePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;       

        private Command _newTramiteCommand;
        private Command _addDocsCommand;
        private UsuarioResponse _usuario;
        public Tramite Tramite { get; set; }
        public bool IsVisibleButtonDoc { get; set; }

        public DelegateCommand<object> SelectionChangedTT { get; set; }
        public DelegateCommand<object> SelectionChangedFP { get; set; }
        public Command NewTramiteCommand => _newTramiteCommand ?? (_newTramiteCommand = new Command(NewTramite));
        public Command AddDocsCommand    => _addDocsCommand    ?? (_addDocsCommand = new Command(AddDocs));
        public ObservableCollection<TipoTramiteResponse> TiposTramite { get; set; }
        public ObservableCollection<FormaDepago> FormasDePago { get; set; }
        public TipoTramiteResponse SelectedTipoTramite { get; set; }
        public FormaDepago SelectedFormaDePago { get; set; }
        public NuevoTramitePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            SelectionChangedTT = new DelegateCommand<object>(SetContentTT);
            SelectionChangedFP = new DelegateCommand<object>(SetContentFP);

            Title              = "Solicitar Tramite";
            IsVisibleButtonDoc = true;
            Tramite            = new Tramite();
            _usuario           = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);
            TiposTramite       = new ObservableCollection<TipoTramiteResponse>(_usuario.TiposTramite.OrderBy(tt => tt.Orden).ToList());
            FormasDePago       = new ObservableCollection<FormaDepago>(_usuario.FormasDePago.OrderBy(tt => tt.IdOpenPay).ToList());
        }

        public void SetContentTT(object obj)
        {
            var selectionChangedArgs = obj as SelectionChangedEventArgs;
            SelectedTipoTramite      = (selectionChangedArgs.Value as TipoTramiteResponse);
            Tramite.TipoTramite      = SelectedTipoTramite.Id.ToString();

            App.Current.MainPage.DisplayAlert("NewTramite", $"NewTramite Model:  {SelectedTipoTramite.Id} - {SelectedTipoTramite.Nombre}", MessageCenter.appLabelAceptar);
        }

        public void SetContentFP(object obj)
        {
            var selectionChangedArgs = obj as SelectionChangedEventArgs;
            SelectedFormaDePago      = (selectionChangedArgs.Value as FormaDepago);
            
            App.Current.MainPage.DisplayAlert("NewTramite", $"Forma de Pago :  {SelectedFormaDePago.Id} - {SelectedFormaDePago.Nombre}", MessageCenter.appLabelAceptar);
        }



        private async void NewTramite(object sender)
        {/*
            var dataForm  = sender as SfDataForm;            
            bool isValidDF = dataForm.Validate();
            dataForm.CollapseGroup(MessageCenter.appGroupName1DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName2DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName3DFTramite);
            */
            var LayoutRoot = sender as Syncfusion.XForms.Accordion.SfAccordion;
            var test = LayoutRoot.FindByName<Syncfusion.XForms.TextInputLayout.SfTextInputLayout>("testField");
            await App.Current.MainPage.DisplayAlert("NewTramite", $"NewTramite Model: {test.HasError} -- {Tramite.TipoTramite} - {Tramite.Verificacion} - {Tramite.TipoPago} - {Tramite.Monto}", MessageCenter.appLabelAceptar);
            
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
