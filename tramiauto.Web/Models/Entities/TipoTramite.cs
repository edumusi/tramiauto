using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class TipoTramite
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tramite")]
        [Required(ErrorMessage = MessageCenter.labelTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(300, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public string Descripcion { get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage          = MessageCenter.labelTextFieldRequired)]
        [MaxLength(7, ErrorMessage      = MessageCenter.labelTextFieldMaxLength)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Costo { get; set; }

        [Display(Name = "Días Habiles")]
        [Required(ErrorMessage     = MessageCenter.labelTextFieldRequired)]
        [MaxLength(5, ErrorMessage = MessageCenter.labelTextFieldMaxLength)]
        public int TiempoOperacion { get; set; }

        /**************RELATIONSHIP*****************/
        public ICollection<Tramite> Tramites { get; set; }



    }//CLASS
}//NAMESPACE
