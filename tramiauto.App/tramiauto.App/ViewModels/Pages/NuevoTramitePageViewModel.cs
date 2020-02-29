using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tramiauto.Common;
using tramiauto.Common.Model.Response;
using Xamarin.Forms;

namespace tramiauto.App.ViewModels.Pages
{
    public class NuevoTramitePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand             _getTipoTramiteCommand;
        private ObservableCollection<TipoTramiteResponse> _tipoTramites;

        public ObservableCollection<TipoTramiteResponse> TipoTramites
        {
            get => _tipoTramites;
            set => SetProperty(ref _tipoTramites, value);
        }

        public DelegateCommand GetTipoTramiteCommand => _getTipoTramiteCommand ?? (_getTipoTramiteCommand = new DelegateCommand(GetTipoTramite));

        public NuevoTramitePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Solicitar Tramite";
            TipoTramites = new ObservableCollection<TipoTramiteResponse>
            {
                new TipoTramiteResponse() { Id = 1, Nombre = "EMS1" },
                new TipoTramiteResponse() { Id = 2, Nombre = "EMS2" }
            };
        }

        private void GetTipoTramite()//(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
           // DisplayAlert("Selection Changed", "SelectedIndex: " + comboBox.SelectedIndex, "OK");
            App.Current.MainPage.DisplayAlert("VER", $"Entro new tramite ", MessageCenter.appLabelAceptar);

        }

    }

    public class DataTemplateSelectorViewModel : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SpecificDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as TipoTramiteResponse;
            App.Current.MainPage.DisplayAlert("VER", $"Entro Tipo Tramite {message.Nombre}", MessageCenter.appLabelAceptar);

           
                return null;
           // return message.IsAvaiableInStock == false ? SpecificDataTemplate : DefaultTemplate;
        }

    }
}
