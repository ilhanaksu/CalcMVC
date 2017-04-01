using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class LoginModel
    {
      
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
       
        [Display(Name = "Password ")]
        [Required]
        public string Password { get; set; }
    }
}