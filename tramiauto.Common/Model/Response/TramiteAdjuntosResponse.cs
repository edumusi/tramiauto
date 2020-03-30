using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model.Response
{
    public class TramiteAdjuntosResponse
    {
        public int Id { get; set; }

        public int Orden { get; set; }

        [Display(Name = "Requisito")]        
        public string Requisito { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Ruta")]        
        public string Ruta { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://tramiauto.azurewebsites.net/images/TramitesAdjuntos/{Ruta}";
    }
}
