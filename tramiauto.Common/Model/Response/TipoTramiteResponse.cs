using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model.Response
{
    public class TipoTramiteResponse
    {
        public int Id { get; set; }
        [Display(Name = "Orden")]
        public int Orden { get; set; }

        [Display(Name = "Tramite")]        
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]        
        public string Descripcion { get; set; }

        [Display(Name = "Costo")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]        
        public decimal Costo { get; set; }

        [Display(Name = "Costo de Tramite Urgente")]        
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]        
        public decimal CostoUrgente { get; set; }

        [Display(Name = "Costo de Atención Ejecutiva")]        
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]        
        public decimal CostoAtencionEjecutiva { get; set; }

        [Display(Name = "Días Habiles")]        
        public int TiempoOperacion { get; set; }
    }
}
