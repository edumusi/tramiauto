using System;
using System.ComponentModel.DataAnnotations;


namespace tramiauto.Common.Model
{
    public class EmailRequest
    {
        [Required    (ErrorMessage = MessageCenter.labelTextEmailRequired)]
        [EmailAddress(ErrorMessage = MessageCenter.labelTextEmailInvalid) ]
        public String Email { get; set; }
    }
}
