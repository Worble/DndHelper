using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels
{
    /// <summary>
    /// The login view model for the user controller.
    /// </summary>
    public class UserLoginViewModel
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to remember the user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }
    }
}
