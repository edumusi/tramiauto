using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tramiauto.Common.Model
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}
