using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tramiauto.Common;

namespace tramiauto.Web.Models.Entities
{
    public class Tramite
    {
        [Key]
        public int Id { get; set; }        

        [Display(Name = "Tramite")]
        [Required(ErrorMessage      = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(50, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]        
        [MaxLength(300, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Descripcion { get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage          = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(7, ErrorMessage      = MessageCenter.webAppTextFieldMaxLength)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Costo { get; set; }

        [Display(Name = "Tiempo de Entrega")]
        [Required(ErrorMessage     = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(5, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public int TiempoEntrega { get; set; }

        [Display(Name = "Fecha Entrega")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; }
        [Display(Name = "Fecha Entrega")] 
        public DateTime FechaEntregaLocal => FechaEntrega.ToLocalTime();

        [Display(Name = "Fecha Registro")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistroLocal => FechaRegistro.ToLocalTime();

        [Display(Name = "Estatus")]
        [Required(ErrorMessage     = MessageCenter.webAppTextFieldRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.webAppTextFieldMaxLength)]
        public string Status { get; set; }


        /**************RELATIONSHIP*****************/
        [Display(Name = "Tipo de Tramite")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        public TipoTramite TipoTramite { get; set; }

        [Display(Name = "Adjuntos")] 
        public ICollection<TramiteAdjuntos> Adjuntos { get; set; }

        [Display(Name = "Automotor")]
        [Required(ErrorMessage = MessageCenter.webAppTextFieldRequired)]
        public Automotor Automotor { get; set; }


    }//CLASS
}//NAMESPACE
