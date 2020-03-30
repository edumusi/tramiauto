using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tramiauto.Common;
using Openpay.Xamarin.Abstractions;
using tramiauto.Common.Model.DataEntity;

namespace tramiauto.App.Model
{
    public class TramiteAPP : Tramite, INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
                
        
        private string _tipoPago;
        [Display (Order = 0, ShortName = "Método de Pago", Prompt = "Pago", GroupName = MessageCenter.appGroupName3DFTramite)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es Tipo de Pago es obligatorio")]
        public string TipoPago
        {   get { return _tipoPago; }
            set { _tipoPago = value;
                  RaisePropertyChanged("TipoPago");
                }
        }

        private Card _card;        
        public Card Card
        {
            get { return _card; }
            set
            {
                _card = value;
                RaisePropertyChanged("Card");
            }
        }

        private bool _isUrgent;
        [Display(Order = 2, ShortName = "¿Tramite urgente?", GroupName = MessageCenter.appGroupName3DFTramite)]        
        public bool IsUrgent
        { get { return _isUrgent; }
          set { _isUrgent = value;
                RaisePropertyChanged("IsUrgent");
              }
        }
        /*****************************  GroupName - Pago  ******************************/

        public TramiteAPP()
        {

        }


        [Display(AutoGenerateField = false)]
        public bool HasErrors
        { get { return false; } }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            var list = new List<string>();
            /*
            if (propertyName.Equals("Tenencia"))
            {
                if (Tenencia.Contains("Test"))
                    list.Add("Test is not allowed");
            }
            
            else if (propertyName.Equals("Password"))
            {
                if (!this.passwordRegExp.IsMatch(this.Password))
                {
                    list.Add("Password must contain at least one digit, one uppercase character and one special symbol");
                }
            }
            */
            return list;
        }

       
    }//Class
}//Namespace
