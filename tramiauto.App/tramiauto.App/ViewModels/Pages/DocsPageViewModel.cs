using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tramiauto.App.Model;
using tramiauto.Common;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model.Response;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

namespace tramiauto.App.ViewModels.Pages
{
    public class DocsPageViewModel : ViewModelBase, INavigationAware
    {
        public DelegateCommand<object> SelectionChangedCommand { get; set; }

        private TramiteAPP _tramite;
        private string _tipoTramite;
        private Command _openGalleryTappedCommand;
        private Command _takeAPhotoTappedCommand;
        private DelegateCommand _imageTappedCommand;

        public DocsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SelectionChangedCommand = new DelegateCommand<object>(SetContent);

            _tipoTramite  = string.Empty;
            Doc1Label     = "Test1";
            Doc2Label     = "Test2";
            IsTakePhoto   = false;
            IsOpenGallery = false;
            ImageModel    = new ImageModel();
            Requisitos    = new ObservableCollection<RequisitoResponse> { new RequisitoResponse { Id = 0, Orden = 0, Nombre = "Seleccione el tipo de tramite a realizar en pantalla anterior" } };
        }

        public Command   OpenGalleryTappedCommand => _openGalleryTappedCommand ?? (_openGalleryTappedCommand = new Command(OpenGalleryTapped));
        public Command    TakeAPhotoTappedCommand => _takeAPhotoTappedCommand  ?? (_takeAPhotoTappedCommand = new Command(TakeAPhotoTapped));
        public DelegateCommand ImageTappedCommand => _imageTappedCommand       ?? (_imageTappedCommand      = new DelegateCommand(ImageTapped));        
        public bool IsTakePhoto      { get; set; }
        public bool IsOpenGallery    { get; set; }
        public ImageModel ImageModel { get; set; }
        public string     Doc1Label  { get; set; }
        public string     Doc2Label  { get; set; }
        public ObservableCollection<RequisitoResponse> Requisitos { get; set; }

        public RequisitoResponse SelectedRequisito { get; set; }

        public TramiteAPP Tramite
        {   get => _tramite;
            set => SetProperty(ref _tramite, value);
        }

        private async void OpenGalleryTapped(object sender)
        {
            if (SelectedRequisito.Id == 0 || SelectedRequisito.Orden == 0)
            {
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorTram, MessageCenter.appLabelErrorTR, MessageCenter.appLabelAceptar);
                return;
            }
            
            var LayoutRoot   = sender as Grid;
            var TakePhoto    = LayoutRoot.FindByName<Image>("TakePhoto");
            TakePhoto.Source = ImageModel.ChooseImageSel;
            IsTakePhoto      = false;

            var OpenGallery = LayoutRoot.FindByName<Image>("OpenGallery");
            if (!IsOpenGallery)
            {   OpenGallery.Source = ImageModel.ChooseImage;
                IsOpenGallery      = true;
            }
            else
            {   OpenGallery.Source = ImageModel.ChooseImageSel;
                IsOpenGallery      = false;
            }

            await App.Current.MainPage.DisplayAlert("OpenGalleryTapped", $"Docs: [{Tramite?.Costo}]", MessageCenter.appLabelAceptar);
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {                
                await App.Current.MainPage.DisplayAlert("no upload", "picking a photo is not supported", "ok");
                return;
            }

            var file  = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            var Doc1    = LayoutRoot.FindByName<Image>("Doc1");
            Doc1.Source = ImageSource.FromStream(() => file.GetStream());

            Doc1Label = "Doc " + SelectedRequisito.Nombre + " por cargar";
            RaisePropertyChanged("Doc1Label");

        }

        private async void TakeAPhotoTapped(object sender)
        { if (SelectedRequisito.Id == 0 || SelectedRequisito.Orden==0 )
            { 
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorTram, MessageCenter.appLabelErrorTR, MessageCenter.appLabelAceptar);
                return; 
            } 
            await CrossMedia.Current.Initialize(); 
            
            var LayoutRoot     = sender as Grid;
            var OpenGallery    = LayoutRoot.FindByName<Image>("OpenGallery");
            OpenGallery.Source = ImageModel.ChooseImageSel;
            IsOpenGallery      = false;

            var TakePhoto = LayoutRoot.FindByName<Image>("TakePhoto");                        
            if (!IsTakePhoto)
            {   TakePhoto.Source = ImageModel.TakePicSelected;
                IsTakePhoto      = true;
            }
            else
            {   TakePhoto.Source = ImageModel.TakePic;
                IsTakePhoto      = false;
            }            
            

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {   await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorNoCam, MessageCenter.appLabelErrorNoCamara, MessageCenter.appLabelAceptar);
                return;
            }

            var optionsCam = new StoreCameraMediaOptions(){ SaveToAlbum        = true,
                                                            Directory          = MessageCenter.appDirDocs,
                                                            Name               = "Doc_"+Tramite.TipoTramite +"_"+ SelectedRequisito.Id + "_" + DateTime.Now.ToString("yyMMddTHHmmss") + ".jpg",
                                                            CompressionQuality = 75,
                                                            PhotoSize          = PhotoSize.Small
                                                           };            
            var file = await CrossMedia.Current.TakePhotoAsync(optionsCam);

            if (file == null)
                return;
            
            await App.Current.MainPage.DisplayAlert("File Location", $" [{file.Path}]", MessageCenter.appLabelAceptar);
           
            var Doc2    = LayoutRoot.FindByName<Image>("Doc2");
            Doc2.Source = ImageSource.FromStream(() => file.GetStream());
            Doc2Label   = "Doc " + SelectedRequisito.Nombre + " por cargar";
            RaisePropertyChanged("Doc2Label");

            await App.Current.MainPage.DisplayAlert("TakeAPhotoTapped", $"Docs: [{Tramite?.Costo}]", MessageCenter.appLabelAceptar);
        }

        private async void ImageTapped()
        {
            if (SelectedRequisito.Id == 0 || SelectedRequisito.Orden == 0)
            {
                await App.Current.MainPage.DisplayAlert(MessageCenter.appLabelErrorTram, MessageCenter.appLabelErrorTR, MessageCenter.appLabelAceptar);
                return;
            }

            await App.Current.MainPage.DisplayAlert("Requisito", $"Req: [{SelectedRequisito.Id}]", MessageCenter.appLabelAceptar);
        }

        public void SetContent(object obj)
        {
            var selectionChangedArgs = obj as SelectionChangedEventArgs;
            SelectedRequisito        = (selectionChangedArgs.Value as RequisitoResponse);            
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {            
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("tramite"))
               { 
                 Tramite = parameters.GetValue<TramiteAPP>("tramite");

                 UsuarioResponse _usuario = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);                  
                                
                 _tipoTramite = _usuario.TiposTramite.Where(Wutt => Wutt.Id == Tramite.TipoTramite.Id).Select(Sutt => Sutt.Nombre).FirstOrDefault().ToString();
               // Requisitos    = new ObservableCollection<RequisitoResponse>(Tramite.Adjuntos.OrderBy(r => r.Orden).ToList<RequisitoResponse>());
                Requisitos   =  new ObservableCollection<RequisitoResponse>(_usuario.Requisitos.Where(Wutt => Wutt.IdTipoTramite == Tramite.TipoTramite.Id).OrderBy(r => r.Orden).ToList<RequisitoResponse>());                 

                RaisePropertyChanged("Requisitos");
               }

            Title = MessageCenter.appTitleDocsTramite + _tipoTramite;
        }

    }//Class
}//Namespace
