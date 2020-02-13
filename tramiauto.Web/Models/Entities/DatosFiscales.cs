using System.ComponentModel.DataAnnotations;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class DatosFiscales
    {        
        [Key]
        [Display(Name = "Registro Federal de Contribuyente")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Rfc { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Calle { get; set; }

        [Display(Name = "Número Exterior")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(6, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public int NumeroExterior { get; set; }

        [Display(Name = "Número Interior")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string NumeroInterior { get; set; }

        [Display(Name = "Colonia")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Colonia { get; set; }

        [Display(Name = "Alcaldia/Municipio")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(60, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string AlcaldiaMunicipio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage      = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Estado { get; set; }

        [Display(Name = "Código Postal")]
        [Required(ErrorMessage     = MessageCenter.labelTextFieldRequired)]
        [MaxLength(6, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public int CodigoPostal { get; set; }

        [Display(Name = "Domicilio Fiscal")]
        public string DomicilioFiscal => $"{Calle} {NumeroExterior} {NumeroInterior} {Colonia} {AlcaldiaMunicipio} {Estado} CP {CodigoPostal}";
    }
}
