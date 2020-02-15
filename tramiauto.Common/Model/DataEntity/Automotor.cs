using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using tramiauto.Common;

namespace tramiauto.Common.Model.DataEntity
{
    public class Automotor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Número de Motor")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string NumeroMotor { get; set; }

        [Display(Name = "Número de Serie")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string NumeroSerie { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(10, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Modelo { get; set; }

        [Display(Name = "Tipo de Automotor")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Tipo { get; set; }

        /**************RELATIONSHIP*****************/
        [Display(Name = "Adjuntos")]
        public ICollection<Tramite> Tramites { get; set; }
    }
}
