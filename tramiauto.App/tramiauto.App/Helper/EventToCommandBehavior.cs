
using Newtonsoft.Json;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tramiauto.App.Model;
using tramiauto.Common.Helpers;
using tramiauto.Common.Model.Response;
using Xamarin.Forms;

namespace tramiauto.App
{
    public class EventToCommandBehavior : BehaviorBase<SfDataForm>
    {
        Delegate eventHandler;

        public static readonly BindableProperty EventNameProperty          = BindableProperty.Create("EventName", typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);
        public static readonly BindableProperty CommandProperty            = BindableProperty.Create("Command", typeof(ICommand), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty CommandParameterProperty   = BindableProperty.Create("CommandParameter", typeof(object), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty EventArgsConverterProperty = BindableProperty.Create("Converter", typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value);         }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value);           }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter EventArgsConverter
        {
            get { return (IValueConverter)GetValue(EventArgsConverterProperty); }
            set { SetValue(EventArgsConverterProperty, value);                  }
       }

        protected override void OnAttachedTo(SfDataForm dataForm)
        {
            base.OnAttachedTo(dataForm);
            RegisterEvent(EventName);

            dataForm.SourceProvider = new SourceProviderExt();
            dataForm.RegisterEditor("TipoTramite", "Picker");
            // dataForm.ItemManager = new DataFormItemManagerExt(dataForm);            

            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

        }
        
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.Name == "TipoTramite")
            {
                (e.DataFormItem as DataFormPickerItem).DisplayMemberPath = "Nombre";
                (e.DataFormItem as DataFormPickerItem).ValueMemberPath   = "Id";
                e.DataFormItem.ShowLabel = false;
            }

            if (e.DataFormGroupItem != null && e.DataFormGroupItem.GroupName == "Documentos")
                e.DataFormGroupItem.IsExpanded = false;

            if (e.DataFormGroupItem != null && e.DataFormGroupItem.GroupName == "Pago")
                e.DataFormGroupItem.IsExpanded = false;
        }

        protected override void OnDetachingFrom(SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            DeregisterEvent(EventName);
        }

        void RegisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
               { return; }

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo == null)
               { throw new ArgumentException(string.Format("EventToCommandBehavior: Can't register the '{0}' event.", EventName)); }

            MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, eventHandler);
        }

        void DeregisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
               { return; }

            if (eventHandler == null)
               { return; }

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo == null)
               { throw new ArgumentException(string.Format("EventToCommandBehavior: Can't de-register the '{0}' event.", EventName)); }

            eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
            eventHandler = null;
        }

        void OnEvent(object sender, object eventArgs)
        {
            if (Command == null)
               { return;    }

            object resolvedParameter;
            if (CommandParameter != null)
               { resolvedParameter = CommandParameter;  }
            else if (EventArgsConverter != null)
                    { resolvedParameter = EventArgsConverter.Convert(eventArgs, typeof(object), AssociatedObject, null);    }
            else
                { resolvedParameter = eventArgs;    }

            if (Command.CanExecute(resolvedParameter))
               { Command.Execute(resolvedParameter); }
        }
        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventToCommandBehavior)bindable;
            if (behavior.AssociatedObject == null)
               { return;    }

            string oldEventName = (string)oldValue;
            string newEventName = (string)newValue;

            behavior.DeregisterEvent(oldEventName);
            behavior.RegisterEvent(newEventName);
        }
    }//CLASS EventToCommandBehavior
    /*
    public class SourceProviderExt : SourceProvider
    {
        private readonly UsuarioResponse _usuario = JsonConvert.DeserializeObject<UsuarioResponse>(Settings.Usuario);
        public override IList GetSource(string sourceName)
        {
            if (sourceName == "TipoTramite")
            { return _usuario.TiposTramite.ToList<TipoTramiteResponse>(); }

            return new List<string>();

        }
    }//Class SourceProviderExt
    */
}
