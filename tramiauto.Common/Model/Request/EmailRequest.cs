using System;
using System.ComponentModel.DataAnnotations;


namespace tramiauto.Common.Model.Request
{
    public class EmailRequest
    {
        [Required    (ErrorMessage = MessageCenter.webAppTextEmailRequired)]
        [EmailAddress(ErrorMessage = MessageCenter.webAppTextEmailInvalid) ]
        public String Email { get; set; }
    }
}
