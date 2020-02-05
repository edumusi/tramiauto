using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tramiauto.Web.Models.Entities
{
    public class Usuario 
    {               

        [Key]
        public int Id { get; set; }

        public UserLogin UserLogin { get; set; }


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
        public string CellPhone => $"{UserLogin.PhoneNumber} ";

        [Display(Name = "Correo Electrónico")]
        public string Correo  => $"{UserLogin.Email} ";

        [Display(Name = "Nombre del Usuario")] 
        public string FullName => $"{FirstName} {LastName}";

        /**************RELATIONSHIP*****************/
        [Display(Name = "Automotores")]
        public ICollection<Automotor> Automotores { get; set; }

        [Display(Name = "Dirección Fiscal")]
        public DatosFiscales DatosFiscales { get; set; }

    }
}
