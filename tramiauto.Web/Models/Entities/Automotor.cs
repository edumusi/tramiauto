using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class Automotor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Número de Motor")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string NumeroMotor { get; set; }

        [Display(Name = "Número de Serie")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string NumeroSerie { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(10, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Modelo { get; set; }

        [Display(Name = "Tipo de Automotor")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Tipo { get; set; }

        /**************RELATIONSHIP*****************/
        [Display(Name = "Adjuntos")]
        public ICollection<Tramite> Tramites { get; set; }
    }
}
