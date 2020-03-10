using Xamarin.Forms;
using Syncfusion.XForms.DataForm;

namespace tramiauto.App
{
    public class DataFormLoginBehavior : Behavior<ContentPage>
    {

        SfDataForm dataForm = null;        
        protected override void OnAttachedTo(ContentPage bindable)
        {

            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dfLogin");

            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

        }
       
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {           
            if (e.DataFormItem.Name == "Email" )
                e.DataFormItem.ImageSource = ImageSource.FromFile("ic_action_person.png");

            if (e.DataFormItem.Name == "Password")
                e.DataFormItem.ImageSource = ImageSource.FromFile("ic_action_map.png");

            if (e.DataFormItem.Name == "RememberMe")
                e.DataFormItem.Editor = "Switch";
        }
        
    }//Class
    
    
    }//Namespace
