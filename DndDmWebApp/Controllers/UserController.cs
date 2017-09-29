using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls all user webpages
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class UserController : BaseController
    {
        #region data members and ctor        
        /// <summary>
        /// The work
        /// </summary>
        private IUnitOfWork work;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public UserController(IUnitOfWork work)
        {
            this.work = work;
        }
        #endregion

        #region methods

        /// <summary>
        /// Displays the register page.
        /// </summary>
        /// <returns></returns>
        [HttpGet("register/"), AllowAnonymous]
        public IActionResult Register()
        {
            return View(new UserRegisterViewModel());
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("register/"), ValidateAntiForgeryToken, AllowAnonymous]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (!work.UserRepository.CheckUniqueEmail(model.EmailAddress))
            {
                ModelState.AddModelError("EmailAddress", "Email Address already exists.");
            }
            if (ModelState.IsValid)
            {
                work.UserRepository.Register(model.EmailAddress, model.Password);
                work.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        /// <summary>
        /// Displays the login page
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet("login/"), AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel() { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("login/"), ValidateAntiForgeryToken, AllowAnonymous]
        public IActionResult Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = work.UserRepository.Login(model.EmailAddress, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("Invalid Login", "Invalid Credentials");
                return View(model);
            }

            var ClaimsPrincipal = Helper.SetClaims(user);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, ClaimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                });

            string decodedUrl = string.Empty;
            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                decodedUrl = WebUtility.HtmlDecode(model.ReturnUrl);
                if (Url.IsLocalUrl(decodedUrl))
                {
                    return this.Redirect(decodedUrl);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Logouts this user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("logout/"), AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
