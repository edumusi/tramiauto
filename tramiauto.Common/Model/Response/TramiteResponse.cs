
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace tramiauto.Common.Model.Response
{
    public class TramiteResponse
    {
        public int Id { get; set; }

        [Display(Name = "Tramite")]        
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]        
        public string Descripcion { get; set; }

        [Display(Name = "Costo")]        
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]        
        public decimal Costo { get; set; }

        [Display(Name = "Tiempo de Entrega")]        
        public int TiempoEntrega { get; set; }

        [Display(Name = "Fecha Entrega")]        
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; }

        [Display(Name = "Fecha Entrega Local")]
        public DateTime FechaEntregaLocal => FechaEntrega.ToLocalTime();

        [Display(Name = "Fecha Registro")]        
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Fecha Registro Local")]
        public DateTime FechaRegistroLocal => FechaRegistro.ToLocalTime();

        [Display(Name = "Estatus")]        
        public string Status { get; set; }
       
        [Display(Name = "Tipo de Tramite")]
        public TipoTramiteResponse TipoTramite { get; set; }

        [Display(Name = "Adjuntos")]
        public ICollection<TramiteAdjuntosResponse> AdjuntosResponse { get; set; }

        [Display(Name = "Automotor")]        
        public AutomotorResponse AutomotorResponse { get; set; }

        public string FirstAdjunto => AdjuntosResponse == null || AdjuntosResponse.Count == 0
                                    ? "https://tramiauto.azurewebsites.net/images/noImage.png"
                                    : AdjuntosResponse.FirstOrDefault().ImageFullPath
                                    ;

    }//Class
}//Namespace
