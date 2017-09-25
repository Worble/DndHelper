using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// The base controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public ApplicationUser CurrentUser
        {
            get
            {
                return new ApplicationUser(this.User as ClaimsPrincipal);
            }
        }
    }
}
