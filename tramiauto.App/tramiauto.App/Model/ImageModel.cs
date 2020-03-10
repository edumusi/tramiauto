using System.Reflection;
using tramiauto.Common;
using Xamarin.Forms;
using System;

namespace tramiauto.App.Model
{
    public class ImageModel
    {
        public ImageSource TakePic         { get; set; }
        public ImageSource TakePicSelected { get; set; }
        public ImageSource ChooseImage     { get; set; }
        public ImageSource ChooseImageSel  { get; set; }
        public ImageSource BroweImage1     { get; set; }
        public ImageSource BroweImage2     { get; set; }
        public ImageSource BroweImage3     { get; set; }

        public ImageModel()
        {
            ChooseImage     = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "Gallery_S.png") );
            TakePic         = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "Take_Photo_W.png") );
            ChooseImageSel  = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "Gallery_W.png") );
            TakePicSelected = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "Take_Photo_S.png") );
            BroweImage1     = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "ALTA.jpg") );
            BroweImage2     = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "CAMBIO.jpg") );
            BroweImage3     = ImageSource.FromUri(new Uri(MessageCenter.URL_IMG_APP + "REPO.jpg") );
        }
    }
}
