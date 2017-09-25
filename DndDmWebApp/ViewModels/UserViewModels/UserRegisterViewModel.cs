using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels
{
    /// <summary>
    /// The register view model for the user controller
    /// </summary>
    public class UserRegisterViewModel
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required.")]
        [EmailAddress(ErrorMessage = "Please use a valid Email Address.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password is required.")] 
        [DataType("Password")]
        [MinLength(6, ErrorMessage = "Passwords require a minimum of 6 characters.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password verify.
        /// </summary>
        /// <value>
        /// The password verify.
        /// </value>
        [Display(Name = "Confirm your password")]
        [Required(ErrorMessage = "Please confirm your password."), DataType("Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordVerify { get; set; }       
    }
}
