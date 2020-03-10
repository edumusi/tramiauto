using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using tramiauto.App.Model;
using tramiauto.Common;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model.Response;
using Xamarin.Forms;

namespace tramiauto.App.ViewModels.Pages
{
    public class DocsPageViewModel : ViewModelBase
    {
        private Tramite _tramite;
        
        private Command _openGalleryTappedCommand;
        private Command _takeAPhotoTappedCommand;
        private DelegateCommand _imageTappedCommand;

        public DocsPageViewModel(INavigationService navigationService) : base(navigationService)
        {            
            IsTakePhoto   = false;
            IsOpenGallery = false;
            ImageModel    = new ImageModel();
        }

        public Command OpenGalleryTappedCommand => _openGalleryTappedCommand ?? (_openGalleryTappedCommand = new Command(OpenGalleryTapped));
        public Command TakeAPhotoTappedCommand  => _takeAPhotoTappedCommand  ?? (_takeAPhotoTappedCommand = new Command(TakeAPhotoTapped));
        public DelegateCommand ImageTappedCommand => _imageTappedCommand ?? (_imageTappedCommand      = new DelegateCommand(ImageTapped));
        public bool IsTakePhoto   { get; set; }
        public bool IsOpenGallery { get; set; }

        public ImageModel ImageModel { get; set; }

        public Tramite Tramite
        {
            get => _tramite;
            set => SetProperty(ref _tramite, value);
        }

        private void OpenGalleryTapped(object sender)
        {
            IsTakePhoto     = false;
            var OpenGallery = sender as Image;
            if (!IsOpenGallery)
            {   OpenGallery.Source = ImageModel.ChooseImage;
                IsOpenGallery      = true;
            }
            else
            {   OpenGallery.Source = ImageModel.ChooseImageSel;
                IsOpenGallery      = false;
            }
            App.Current.MainPage.DisplayAlert("OpenGalleryTapped", $"Docs: [{Tramite?.Monto}]", MessageCenter.appLabelAceptar);
        }

        private void TakeAPhotoTapped(object sender)
        {
            IsOpenGallery = false;
            var TakePhoto = sender as Image;
            if (!IsTakePhoto)
            {   TakePhoto.Source = ImageModel.TakePicSelected;
                IsTakePhoto      = true;
            }
            else
            {   TakePhoto.Source = ImageModel.TakePic;
                IsTakePhoto      = false;
            }
            App.Current.MainPage.DisplayAlert("TakeAPhotoTapped", $"Docs: [{Tramite?.Monto}]", MessageCenter.appLabelAceptar);
        }

        private void ImageTapped()
        {
            App.Current.MainPage.DisplayAlert("ImageTapped", $"Docs: [{Tramite?.Monto}]", MessageCenter.appLabelAceptar);
        }
        

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            string TipoTramite = string.Empty;
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("tramite"))
               { 
                 Tramite = parameters.GetValue<Tramite>("tramite");
                 UsuarioResponse _usuario = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario); 
                 int.TryParse(Tramite.TipoTramite, out int tt);
                 TipoTramite = _usuario.TiposTramite.Where(Wutt => Wutt.Id == tt).Select(Sutt => Sutt.Nombre).FirstOrDefault().ToString();
                }

            Title = MessageCenter.appTitleDocsTramite + $"{TipoTramite}";
        }

    }//Class
}//Namespace
