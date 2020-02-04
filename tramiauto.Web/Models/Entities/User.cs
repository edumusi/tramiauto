using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tramiauto.Web.Models.Entities
{
    public class User
    {
        [Key]
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]        
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Email { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]

        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(30, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string LastName { get; set; }

        [Display(Name = "Teléfono Fijo")]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string FixedPhone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string CellPhone { get; set; }

        [Display(Name = "Nombre del Usuario")] 
        public string FullName => $"{FirstName} {LastName}";

        /**************RELATIONSHIP*****************/
        [Display(Name = "Automotores")]
        public ICollection<Automotor> Automotores { get; set; }

        [Display(Name = "Dirección Fiscal")]
        public DatosFiscales DatosFiscales { get; set; }

    }
}
