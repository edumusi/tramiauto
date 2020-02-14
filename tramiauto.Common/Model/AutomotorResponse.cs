using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model
{
    public class AutomotorResponse
    {
        public int Id { get; set; }

        [Display(Name = "Número de Motor")]        
        public string NumeroMotor { get; set; }

        [Display(Name = "Número de Serie")]        
        public string NumeroSerie { get; set; }

        [Display(Name = "Marca")]        
        public string Marca { get; set; }

        [Display(Name = "Modelo")]        
        public string Modelo { get; set; }

        [Display(Name = "Tipo de Automotor")]        
        public string Tipo { get; set; }
    }//Class
}//Namespace
