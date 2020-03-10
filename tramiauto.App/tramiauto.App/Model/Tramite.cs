using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using tramiauto.Common;

namespace tramiauto.App.Model
{
    public class Tramite : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /*****************************  GroupName - Tipo Tramite  ******************************/
        private string _tipoTramite;
        [Display (Order = 0, ShortName = "Tipo de Tramite", Prompt = "Seleccione Tipo de Tramite", GroupName = MessageCenter.appGroupName1DFTramite)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name should not be empty")]
        public string TipoTramite 
        {   get { return _tipoTramite; }
            set { _tipoTramite = value;
                  RaisePropertyChanged("TipoTramite");
                }
        }
        /*****************************  GroupName - Tipo Tramite  ******************************/


        /*****************************  GroupName - Documentos  ******************************/
        [Display(Name = "Image", Order = 0, GroupName = MessageCenter.appGroupName2DFTramite)]
        public string TenenciaImage { get; set; }
        /*
        private string _tenencia;
        [DisplayOptions(ValidMessage = "Documentos length is enough", ImageName = "ic_action_map.png")]        
        [Display       (Order = 0, ShortName = "Tenencia", Prompt = "Tenencia", GroupName = MessageCenter.appGroupName2DFTramite)]        
        [Required      (AllowEmptyStrings = false, ErrorMessage = "Documentos should not be empty")]
        [StringLength  (10, ErrorMessage = "Documentos should not exceed 10 characters")]
        public string Tenencia
        {   get { return _tenencia; }
            set { _tenencia = value;
                  RaisePropertyChanged("Tenencia");
                  GetErrors("Tenencia");
                }
        }
        */

        private string _verificacion;
        [Display     (Order = 1, ShortName = "Verificacion", Prompt = "Verificacion", GroupName = MessageCenter.appGroupName2DFTramite)]
        [Required    (AllowEmptyStrings = false, ErrorMessage = "Docs should not be empty")]
        [StringLength(3, ErrorMessage = "Doc1 should not exceed 3 characters")]
        public string Verificacion 
        {   get { return _verificacion; }
            set { _verificacion = value;
                  RaisePropertyChanged("TipoTramite");
                }
        }
        /*****************************  GroupName - Documentos  ******************************/


        /*****************************  GroupName - Pago  ******************************/
        private string _tipoPago;
        [Display (Order = 0, ShortName = "Método de Pago", Prompt = "Pago", GroupName = MessageCenter.appGroupName3DFTramite)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es Tipo de Pago es obligatorio")]
        public string TipoPago
        {   get { return _tipoPago; }
            set { _tipoPago = value;
                  RaisePropertyChanged("TipoPago");
                }
        }

        private double? _monto;
        [Display (Order = 1, ShortName = "Monto a pagar", Prompt = "TipoPago", GroupName = MessageCenter.appGroupName3DFTramite)]       
        public double? Monto
        {   get { return _monto; }
            set { _monto = value;
                  RaisePropertyChanged("Monto");
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

        public Tramite()
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
