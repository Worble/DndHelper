using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels.Models;
using DndDmWebApp.ViewModels.RaceViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the race webpages
    /// </summary>
    public class RaceController : BaseController
    {
        #region data members and ctor

        private IUnitOfWork work;

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public RaceController(IUnitOfWork work)
        {
            this.work = work;
        }

        #endregion

        #region methods

        public IActionResult Index()
        {
            var model = new RaceIndexViewModel()
            {
                Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e))
            };
            return View(model);
        }

        #endregion
    }
}
