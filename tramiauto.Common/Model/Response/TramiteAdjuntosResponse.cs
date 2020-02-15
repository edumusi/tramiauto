using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model.Response
{
    public class TramiteAdjuntosResponse
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Adjunto")]        
        public string Tipo { get; set; }

        [Display(Name = "Ruta")]        
        public string Ruta { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{Ruta.Substring(1)}";
    }
}
