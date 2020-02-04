using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tramiauto.Web.Models.Entities
{
    public class Automotor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Número de Motor")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string NumeroMotor { get; set; }

        [Display(Name = "Número de Serie")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string NumeroSerie { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(10, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Modelo { get; set; }

        [Display(Name = "Tipo de Automotor")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Tipo { get; set; }

        /**************RELATIONSHIP*****************/
        [Display(Name = "Adjuntos")]
        public ICollection<Tramite> Tramites { get; set; }
    }
}
