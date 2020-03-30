using System.ComponentModel.DataAnnotations;
using tramiauto.Common;

namespace tramiauto.Common.Model.DataEntity
{
    public class TramiteAdjuntos
    {
        [Key]
        public int Id { get; set; }
        public int Orden { get; set; }

        [Display(Name = "Requisito")]        
        [MaxLength(80, ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        public string Requisito { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Ruta")]
        [MaxLength(300, ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        public string Ruta { get; set; }

        // TODO: Change the path when publish        
        public string ImageFullPath => $"https://tramiauto.azurewebsites.net/images/TramitesAdjuntos/{Ruta}";

        /**************RELATIONSHIP*****************/
        [Display(Name = "Tramite")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        public Tramite Tramite { get; set; }
    }
}
