using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineSiparis.Models
{
    public class Login
    {

        [Required]
        [DisplayName("Kollanıcı Adı")]
        public String Name { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public String Password { get; set; }
      
}
}