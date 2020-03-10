using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model.Request
{
    public class TramiteRequest
    {
        [Display(Order = 0, ShortName = "Tipo de Tramite", Prompt = "Seleccione Tipo de Tramite", GroupName = "Tipo Tramite")]
        
        public string TipoTramite { get; set; }


        [Display(Order = 0, ShortName = "Tenencia", Prompt = "Tenencia", GroupName = "Documentos")]
        public string Documentos { get; set; }

        [Display(Order = 1, ShortName = "Verificacion", Prompt = "Verificacion", GroupName = "Documentos")]        
        public string Documentos1 { get; set; }


        [Display(Order = 0, ShortName = "Pago", Prompt = "Pago", GroupName = "Pago")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PAGO")]
        public string Pago { get; set; }

        [Display(Order = 1, ShortName = "TipoPago", Prompt = "TipoPago", GroupName = "Pago")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "TIPO PAGO OBLIGATORIO")]
        public string TipoPago { get; set; }


        public TramiteRequest()
        {

        }
    }//Class
}//Namespace
