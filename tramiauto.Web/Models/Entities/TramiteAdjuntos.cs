using System.ComponentModel.DataAnnotations;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class TramiteAdjuntos
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo Adjunto")]        
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldRequired)]
        public string Tipo { get; set; }

        [Display(Name = "Ruta")]
        [MaxLength(300, ErrorMessage = MessageCenter.labelTextFieldRequired)]
        public string Ruta { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{Ruta.Substring(1)}";

        /**************RELATIONSHIP*****************/
        [Display(Name = "Tramite")]
        [Required(ErrorMessage = MessageCenter.labelTextFieldRequired)]
        public Tramite Tramite { get; set; }
    }
}
