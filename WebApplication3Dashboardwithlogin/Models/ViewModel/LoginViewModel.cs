using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3Dashboardwithlogin.Models.ViewModel
{
    public class LoginViewModel
    {
        public int UserId { get; set; } 

        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Password is required")] 
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
       
    }
}