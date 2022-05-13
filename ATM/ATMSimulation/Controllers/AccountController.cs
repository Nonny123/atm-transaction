using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;


namespace ATMSimulation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
      
        public AccountController()
        {
        }
      

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
        }
       
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    try
        //    {
        //        // Verification.    
        //        if (ModelState.IsValid)
        //        {
        //            // Initialization.    
        //            var loginInfo = this.databaseManager.LoginByUsernamePassword(model.Username, model.Password).ToList();
        //            // Verification.    
        //            if (loginInfo != null && loginInfo.Count() > 0)
        //            {
        //                // Initialization.    
        //                var logindetails = loginInfo.First();
        //                // Login In.    
        //                this.SignInUser(logindetails.username, false);
        //                // Info.    
        //                return this.RedirectToLocal(returnUrl);
        //            }
        //            else
        //            {
        //                // Setting.    
        //                ModelState.AddModelError(string.Empty, "Invalid username or password.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Info    
        //        Console.Write(ex);
        //    }
        //    // If we got this far, something failed, redisplay form    
        //    return this.View(model);
        //}
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            AuthenticationManager.SignOut();
            return this.RedirectToAction("Index", "Home");
        }
        

        //private void SignInUser(string username, bool isPersistent)
        //{
        //    // Initialization.    
        //    var claims = new List<Claim>();
        //    try
        //    {
        //        // Setting    
        //        claims.Add(new Claim(ClaimTypes.Name, username));
        //        var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        //        var ctx = Request.GetOwinContext();
        //        var authenticationManager = ctx.Authentication;
        //        // Sign In.    
        //        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Info    
        //        throw ex;
        //    }
        //}
       
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
       
    }
}