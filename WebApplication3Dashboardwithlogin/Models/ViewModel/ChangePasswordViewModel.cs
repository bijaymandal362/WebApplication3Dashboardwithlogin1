using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3Dashboardwithlogin.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        
        [Display(Name ="User name")]
        [Required(ErrorMessage ="Username Required.")]
       
        public string UserName { get; set; }


        [Display(Name ="Old Password")]
        [Required(ErrorMessage ="OldPassword is required.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        

        [Display(Name ="New Password")]
        [Required(ErrorMessage ="NewPassword is requied")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password must be at least 6 charcter")]
        public string NewPassword { get; set; }


        [Display(Name ="Confirm NewPassword")]
        [Required(ErrorMessage ="ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Compare(otherProperty:"NewPassword",ErrorMessage ="ConfirmPassword is not Matched..!")]
       
 
        public string ConfirmPassword { get; set; }
    }
}