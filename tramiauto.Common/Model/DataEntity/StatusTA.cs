using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tramiauto.Common.Model.DataEntity
{
    public class StatusTA
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(300, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Descripcion { get; set; }
       

        /**************RELATIONSHIP*****************/
        public ICollection<Tramite> Tramites { get; set; }



    }//CLASS
}//NAMESPACE
