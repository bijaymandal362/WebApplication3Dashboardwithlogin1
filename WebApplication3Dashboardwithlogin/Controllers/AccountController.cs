using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using WebApplication3Dashboardwithlogin.Models;
using WebApplication3Dashboardwithlogin.Models.ViewModel;


namespace WebApplication3Dashboardwithlogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        BusinessManagementDBEntities db = new BusinessManagementDBEntities();
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel l , string ReturnUrl = "")
        {
            using (BusinessManagementDBEntities db = new BusinessManagementDBEntities())
            {
                var users = db.tblUserLogins.Where(a => a.UserName == l.UserName && a.Password == l.Password).FirstOrDefault();
                if (users != null)
                {
                    Session.Add("fullname", users.FullName);
                    Session.Add("username", users.UserName);
                    Session.Add("userid", users.UserId);
                    FormsAuthentication.SetAuthCookie(l.UserName, l.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
                return View();
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost,Authorize,ValidateAntiForgeryToken]
       public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            if (ModelState.IsValid)
            {
                
                
                var user = db.tblUserLogins.Where(a => a.UserName == ch.UserName && a.Password == ch.OldPassword).FirstOrDefault();
                if (user!=null)
                {
                    
                    user.Password = ch.NewPassword;
                    db.SaveChanges();
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "OldPassword or username is not correct");
                }
            }

            return View();
        }
       
       

        
     

    }
}