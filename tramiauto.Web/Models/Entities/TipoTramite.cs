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
        [Required(ErrorMessage = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(300, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Descripcion { get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage          = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(7, ErrorMessage      = MessageCenter.labelTextFiedlMaxLength)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Costo { get; set; }

        [Display(Name = "Días Habiles")]
        [Required(ErrorMessage     = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(5, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public int TiempoOperacion { get; set; }

        /**************RELATIONSHIP*****************/
        public ICollection<Tramite> Tramites { get; set; }

        

    }
}
