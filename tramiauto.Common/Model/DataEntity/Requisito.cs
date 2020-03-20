using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tramiauto.Common.Model.DataEntity
{
    public class Requisito
    {       
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tramite")]
        public int Orden { get; set; }

        [Display(Name = "Requisito")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(300, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Descripcion { get; set; }
            
        /**************RELATIONSHIP*****************/
        public TipoTramite TipoTramite { get; set; }
}//Class
}//Namespace
