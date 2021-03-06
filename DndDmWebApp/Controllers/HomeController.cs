﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DndDmWebApp.ViewModels;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels.Models;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls all home webpages.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : BaseController
    {
        #region data members and ctor

        private IUnitOfWork work;

        public HomeController(IUnitOfWork work)
        {
            this.work = work;
        }

        #endregion

        #region methods

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            // handle different codes or just return the default error view
            return View();
        }

        #endregion
    }
}
