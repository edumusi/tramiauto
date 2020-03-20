using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model.Response
{
    public class RequisitoResponse
    {     
        public int Id { get; set; }

        [Display(Name = "Orden")]
        public int Orden { get; set; }

        [Display(Name = "Requisito")]        
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]        
        public string Descripcion { get; set; }
        
        public int  IdTipoTramite { get; set; }
    }
}
