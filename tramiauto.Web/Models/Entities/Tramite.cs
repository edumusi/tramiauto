﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.Entities
{
    public class Tramite
    {
        [Key]
        public int Id { get; set; }        

        [Display(Name = "Tramite")]
        [Required(ErrorMessage      = MessageCenter.labelTextFiedlRequired)]
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

        [Display(Name = "Tiempo de Entrega")]
        [Required(ErrorMessage     = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(5, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public int TiempoEntrega { get; set; }

        [Display(Name = "Fecha Entrega")]
        [Required(ErrorMessage = MessageCenter.labelTextFiedlRequired)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; }
        [Display(Name = "Fecha Entrega")] 
        public DateTime FechaEntregaLocal => FechaEntrega.ToLocalTime();

        [Display(Name = "Fecha Registro")]
        [Required(ErrorMessage = MessageCenter.labelTextFiedlRequired)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistroLocal => FechaRegistro.ToLocalTime();

        [Display(Name = "Estatus")]
        [Required(ErrorMessage     = MessageCenter.labelTextFiedlRequired)]
        [MaxLength(20, ErrorMessage = MessageCenter.labelTextFiedlMaxLength)]
        public string Status { get; set; }


        /**************RELATIONSHIP*****************/
        [Display(Name = "Tipo de Tramite")]
        [Required(ErrorMessage = MessageCenter.labelTextFiedlRequired)]
        public TipoTramite TipoTramite { get; set; }

        [Display(Name = "Adjuntos")] 
        public ICollection<TramiteAdjuntos> Adjuntos { get; set; }

        [Display(Name = "Automotor")]
        [Required(ErrorMessage = MessageCenter.labelTextFiedlRequired)]
        public Automotor Automotor { get; set; }


    }
}
