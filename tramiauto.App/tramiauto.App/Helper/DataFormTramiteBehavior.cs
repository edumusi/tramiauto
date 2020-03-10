using tramiauto.Common.Model.Response;
using Newtonsoft.Json;
using tramiauto.Common.Helpers;
using System.Linq;
using tramiauto.Common;
using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace tramiauto.App
{
    public class DataFormTramiteBehavior : Behavior<ContentPage>
    {

        SfDataForm dataForm = null;        
        protected override void OnAttachedTo(ContentPage bindable)
        {

            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dfTramite");

            dataForm.SourceProvider = new SourceProviderExt();
            dataForm.RegisterEditor("TipoTramite"  , "Picker");                        
          //  dataForm.RegisterEditor("image"        , new CustomImageEditor(dataForm));
          //  dataForm.RegisterEditor("TenenciaImage", "image");

            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

            //dataForm.ItemManager = new DataFormItemManagerExt(dataForm);
        }
       
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.Name == "TipoTramite")
            {
                (e.DataFormItem as DataFormPickerItem).DisplayMemberPath = "Nombre";
                (e.DataFormItem as DataFormPickerItem).ValueMemberPath   = "Id";
                e.DataFormItem.ShowLabel = false;
            }
           
            if (e.DataFormGroupItem != null && e.DataFormGroupItem.GroupName == MessageCenter.appGroupName2DFTramite)
                e.DataFormGroupItem.IsExpanded = false;

            if (e.DataFormGroupItem != null && e.DataFormGroupItem.GroupName == MessageCenter.appGroupName3DFTramite)           
                e.DataFormGroupItem.IsExpanded = false;
        }
        
    }//Class

    public class CustomImageEditor : DataFormEditor<Image>
    {
        public CustomImageEditor(SfDataForm dataForm) : base(dataForm)
        { }
        /*
        protected override Image OnCreateEditorView()
        {
            return new Image();
        }
        */
        
        protected override void OnInitializeView(DataFormItem dataFormItem, Image view)
         { view.Source = ImageSource.FromResource("DataFormSampleForms.flower.png");  }
    }//Class



    public class SourceProviderExt : SourceProvider
    {
        private readonly UsuarioResponse _usuario = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);
        public override IList GetSource(string sourceName)
        {
            if (sourceName == "TipoTramite")
            { return _usuario.TiposTramite.ToList<TipoTramiteResponse>(); }

            return new List<string>();

        }
    }//Class

    public class DataFormItemManagerExt : DataFormItemManager
    {
        SfDataForm sfDataForm;
        public DataFormItemManagerExt(SfDataForm dataForm) : base(dataForm)
        {
            sfDataForm = dataForm;
        }
        protected override List<DataFormItemBase> GenerateDataFormItems(PropertyInfoCollection itemProperties, List<DataFormItemBase> dataFormItems)
        {
            var items = dataFormItems;
            foreach (var propertyInfo in itemProperties)
            {
                DataFormItem dataFormItem;                
                if (propertyInfo.Key == "Monto")
                   {  dataFormItem = new DataFormNumericItem() {  Name = propertyInfo.Key, Editor = "Numeric", MaximumNumberDecimalDigits = 0 };
                      items.Add(dataFormItem);
                      var newDocImage = new Image { Aspect = Aspect.AspectFit, Source = "ic_action_map.png" };
                      //beachImage.Source = ImageSource.FromFile("waterfront.jpg");
                }
            }

            return items;
        }

        public override object GetValue(DataFormItem dataFormItem)
        {
            var value = sfDataForm.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).GetValue(sfDataForm.DataObject);
            return value;
        }

        public override void SetValue(DataFormItem dataFormItem, object value)
        {
            sfDataForm.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).SetValue(sfDataForm.DataObject, value);
        }
    }//Class
    
    }//Namespace
