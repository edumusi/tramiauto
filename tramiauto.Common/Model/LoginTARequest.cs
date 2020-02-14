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

        public string Token { get; set; }
        public string Rol { get; set; }
        public DateTime ValidToken { get; set; }
        public DateTime ExpirationToken { get; set; }
        public bool TokenExpired { get; set; }

    }//class
}//NameSpace
