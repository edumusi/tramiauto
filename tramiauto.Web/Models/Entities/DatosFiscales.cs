using System.ComponentModel.DataAnnotations;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class DatosFiscales
    {        
        [Key]
        [Display(Name = "Registro Federal de Contribuyente")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Rfc { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Calle { get; set; }

        [Display(Name = "Número Exterior")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(6, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public int NumeroExterior { get; set; }

        [Display(Name = "Número Interior")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string NumeroInterior { get; set; }

        [Display(Name = "Colonia")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Colonia { get; set; }

        [Display(Name = "Alcaldia/Municipio")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(60, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string AlcaldiaMunicipio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Estado { get; set; }

        [Display(Name = "Código Postal")]
        [Required(ErrorMessage     = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(6, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public int CodigoPostal { get; set; }

        [Display(Name = "Domicilio Fiscal")]
        public string DomicilioFiscal => $"{Calle} {NumeroExterior} {NumeroInterior} {Colonia} {AlcaldiaMunicipio} {Estado} CP {CodigoPostal}";
    }
}
