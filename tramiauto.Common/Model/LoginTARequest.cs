using System;
using System.ComponentModel.DataAnnotations;

namespace tramiauto.Common.Model
{
    public class LoginTARequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }       

    }//class
}//NameSpace
