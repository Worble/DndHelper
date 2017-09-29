using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels.BaseStatViewModels;
using DndDmWebApp.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the base stat webpages
    /// </summary>
    /// <seealso cref="DndDmWebApp.Controllers.BaseController" />
    public class BaseStatController : BaseController
    {
        #region data members and ctor
        private IUnitOfWork work;

        public BaseStatController(IUnitOfWork work)
        {
            this.work = work;
        }

        #endregion

        #region methods

        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var model = new BaseStatIndexViewModel()
            {
                BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e))
            };
            return View(model);
        }

        #endregion
    }
}
