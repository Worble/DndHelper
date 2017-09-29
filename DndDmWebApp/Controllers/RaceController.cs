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

        /// <summary>
        /// Displays the race index page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RaceIndexViewModel()
            {
                Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e))
            };
            return View(model);
        }

        /// <summary>
        /// Displays the create race page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new RaceCreateViewModel();
            return View(model);
        }

        /// <summary>
        /// Creates the specified race.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(RaceCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            work.RaceRepository.Create(RaceModel.GenerateRaceDTOFromModel(model.Race));
            work.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the race edit page for the given race.
        /// </summary>
        /// <param name="id">The race identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new RaceEditViewModel()
            {
                Race = RaceModel.GenerateRaceModelFromDTO(work.RaceRepository.GetDTO(id))
            };
            return View(model);
        }

        /// <summary>
        /// Edits the specified race.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(RaceEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            work.RaceRepository.Update(RaceModel.GenerateRaceDTOFromModel(model.Race));
            work.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the delete page
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new RaceDeleteViewModel();
            model.Race = RaceModel.GenerateRaceModelFromDTO(work.RaceRepository.GetDTO(id));
            return View(model);
        }

        /// <summary>
        /// Deletes the specified race.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(RaceDeleteViewModel model)
        {
            work.RaceRepository.Delete(model.Race.ID);
            work.Save();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
