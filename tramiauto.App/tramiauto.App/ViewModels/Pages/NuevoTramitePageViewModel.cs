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
using tramiauto.Common.Services;
using Openpay.Xamarin;
using Openpay.Xamarin.Abstractions;

namespace tramiauto.App.ViewModels.Pages
{
    public class NuevoTramitePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private Token _tokenOpenPay;

        private Command _newTramiteCommand;
        private Command _addDocsCommand;
        private UsuarioResponse _usuario;       

        public DelegateCommand<object> SelectionChangedTT { get; set; }
        public DelegateCommand<object> SelectionChangedFP { get; set; }

        public Command NewTramiteCommand => _newTramiteCommand ?? (_newTramiteCommand = new Command(NewTramite));
        public Command AddDocsCommand    => _addDocsCommand    ?? (_addDocsCommand = new Command(AddDocs));

        public ObservableCollection<TipoTramiteResponse> TiposTramite { get; set; }
        public ObservableCollection<FormaDePagoResponse> FormasDePago { get; set; }
                      
        
        private TramiteAPP _tramite;
        public TramiteAPP Tramite
        {
            get => _tramite;
            set => SetProperty(ref _tramite, value);
        }

        private ObservableCollection<Common.Model.DataEntity.TramiteAdjuntos> _docsAdjuntos;
        public ObservableCollection<Common.Model.DataEntity.TramiteAdjuntos> DocsAdjuntos
        {
            get => _docsAdjuntos;
            set => SetProperty(ref _docsAdjuntos, value);
        }


        private bool _visibleFormaPagoCard;
        public bool VisibleFormaPagoCard
        {
            get => _visibleFormaPagoCard;
            set => SetProperty(ref _visibleFormaPagoCard, value);
        }
    
        private bool _visibleFormaPagoBank;
        public bool VisibleFormaPagoBank
        {
            get => _visibleFormaPagoBank;
            set => SetProperty(ref _visibleFormaPagoBank, value);
        }

        private bool _visibleFormaPagoStore;
        public bool VisibleFormaPagoStore
        {
            get => _visibleFormaPagoStore;
            set => SetProperty(ref _visibleFormaPagoStore, value);
        }


        private bool _isRunning;        
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        private bool _isEnabled;        
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private bool _isTestEmpty;
        public string TestField { get; set; }
        public bool IsTestEmpty
        {
            get => _isTestEmpty;
            set => SetProperty(ref _isTestEmpty, value);
        }

       
        public NuevoTramitePageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService        = apiService;
            _usuario           = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);

            SelectionChangedTT = new DelegateCommand<object>(SetContentTT);
            SelectionChangedFP = new DelegateCommand<object>(SetContentFP);

            Title              = "Solicitar Tramite";            
            Tramite            = new TramiteAPP();            
            TiposTramite       = new ObservableCollection<TipoTramiteResponse>(_usuario.TiposTramite.OrderBy(tt => tt.Orden).ToList());
            FormasDePago       = new ObservableCollection<FormaDePagoResponse>(_usuario.FormasDePago.OrderBy(tt => tt.IdOpenPay).ToList());
            IsEnabled          = true;            
        }

        public void SetContentTT(object obj)
        {            
            var selectionChArgs     = obj as SelectionChangedEventArgs;
            var selectedTipoTramite = (selectionChArgs.Value as TipoTramiteResponse);
            Tramite.TipoTramite     = new Common.Model.DataEntity.TipoTramite { Id = selectedTipoTramite.Id, Costo= selectedTipoTramite.Costo, Descripcion = selectedTipoTramite.Descripcion, Nombre = selectedTipoTramite.Nombre, Orden = selectedTipoTramite.Orden, TiempoOperacion = selectedTipoTramite.TiempoOperacion };            
            Tramite.Adjuntos        = _usuario.Requisitos.Where(Wutt => Wutt.IdTipoTramite == Tramite.TipoTramite.Id).Select(a => new Common.Model.DataEntity.TramiteAdjuntos { Requisito=a.Nombre, Descripcion= a.Descripcion, Orden = a.Orden }).OrderBy(r => r.Orden).ToList();
            DocsAdjuntos            = new ObservableCollection<Common.Model.DataEntity.TramiteAdjuntos>(Tramite.Adjuntos.Where(req=>req.Orden != 0).ToList());


            //App.Current.MainPage.DisplayAlert("NewTramite", $"NewTramite Model:  [{Tramite.TipoTramite.Nombre}] - {SelectedTipoTramite.Nombre}", MessageCenter.appLabelAceptar);
        }


        public void SetContentFP(object obj)
        {
            var selectionChArgs     = obj as SelectionChangedEventArgs;
            var selectedFormaDePago = (selectionChArgs.Value as FormaDePagoResponse);
            Tramite.TipoPago        = selectedFormaDePago.Tipo;

            //App.Current.MainPage.DisplayAlert("NewTramite", $"Forma de Pago :  {Tramite.TipoPago} - {SelectedFormaDePago.Nombre}", MessageCenter.appLabelAceptar);

            if (Tramite.TipoPago == MessageCenter.FormaDePagoCard)
               {    VisibleFormaPagoCard  = true;
                    VisibleFormaPagoBank  = false;
                    VisibleFormaPagoStore = false;
                return;
               }

            if (Tramite.TipoPago == MessageCenter.FormaDePagoBank)
                {   VisibleFormaPagoCard  = false;
                    VisibleFormaPagoBank  = true;
                    VisibleFormaPagoStore = false;
                return;
                }

            if (Tramite.TipoPago == MessageCenter.FormaDePagoStore)
                {   VisibleFormaPagoCard  = false;
                    VisibleFormaPagoBank  = false;
                    VisibleFormaPagoStore = true;
                return;
                }
            else
                {   VisibleFormaPagoCard  = false;
                    VisibleFormaPagoBank  = false;
                    VisibleFormaPagoStore = false;               
                }

        }



        private async void NewTramite(object sender)
        {/*
            var dataForm  = sender as SfDataForm;            
            bool isValidDF = dataForm.Validate();
            dataForm.CollapseGroup(MessageCenter.appGroupName1DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName2DFTramite);
            dataForm.ExpandGroup  (MessageCenter.appGroupName3DFTramite);
            */            
            IsRunning   = true;
            IsEnabled   = false;            

            await App.Current.MainPage.DisplayAlert("NewTramite", $"NewTramite Model: {IsTestEmpty} - [{TestField}] - {Tramite.TipoPago} - {Tramite.TipoTramite.Nombre} ", MessageCenter.appLabelAceptar);
            var connect = await _apiService.CheckConnectivityAsync( MessageCenter.URL );
            if (!connect)                
            {   IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorConnect, MessageCenter.appLabelErrorNoInter, MessageCenter.appLabelAceptar);
                return;
            }

            if ( Tramite.TipoTramite.Id == 1 )
            {   IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appTitlePageTramites, MessageCenter.appLabelErrorTT, MessageCenter.appLabelAceptar);
                return;
            }

            if ( Tramite.TipoPago == "4" )
            {   IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(MessageCenter.appTitlePageTramites, MessageCenter.appLabelErrorFP, MessageCenter.appLabelAceptar);
                return;
            }

            var LayoutRoot = sender as Syncfusion.XForms.Accordion.SfAccordion;
            //var test = LayoutRoot.FindByName<Syncfusion.XForms.TextInputLayout.SfTextInputLayout>("testField");
            IsTestEmpty = string.IsNullOrEmpty(TestField);
            if (IsTestEmpty)
            {
                IsEnabled = true;
                IsRunning = false;
                return;
            }

            TokenizeCard();

            //await _navigationService.NavigateAsync("/TramiteMasterDetailPage/NavigationPage/NuevoTramitePage");
        }

        private async void AddDocs(object sender)
        {            
            await App.Current.MainPage.DisplayAlert("AddDocs", $"AddDocsl: {Tramite.TipoTramite} - {Tramite.TipoPago} - {Tramite.Costo}", MessageCenter.appLabelAceptar);

            var paramTramite = new NavigationParameters { { "tramite", Tramite } };
            await _navigationService.NavigateAsync("DocsPage", paramTramite);
            //await _navigationService.NavigateAsync("/TramiteMasterDetailPage/NavigationPage/DocsPage");
        }


        private async void TokenizeCard()
        {            
            try
            {
                if (CrossOpenpay.IsSupported)
                {
                    Card card = new Card{ HolderName      = "Francisco Pantera",
                                          Number          = "4111111111111111",
                                          ExpirationMonth = "12",
                                          ExpirationYear  = "21",
                                          Cvv2            = 132
                                         };

                    _tokenOpenPay = await CrossOpenpay.Current.CreateTokenFromCard(card);                    

                    await App.Current.MainPage.DisplayAlert("Success",$"Token created successfully: {_tokenOpenPay.Id} for card '{_tokenOpenPay.Card.Number}'.", "Ok");
                }
            }
            catch (Exception exception)
                  { await App.Current.MainPage.DisplayAlert($"Error: {exception.Message}", "Error", "Ok"); }
            /*finally
            {
                IsBusy = false;
            }
            */
        }


    }//Class       
}//Namespace
