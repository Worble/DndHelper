using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels.ClassViewModels;
using DndDmWebApp.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the class webpages.
    /// </summary>
    public class ClassController : BaseController
    {
        #region data members and ctor
        private IUnitOfWork work;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public ClassController(IUnitOfWork work)
        {
            this.work = work;
        }

        #endregion

        #region methods

        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ClassIndexViewModel()
            {
                Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e))
            };
            return View(model);
        }

        /// <summary>
        /// Displays the create page. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ClassCreateViewModel();
            return View(model);
        }

        /// <summary>
        /// Creates the specified class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ClassCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            work.ClassRepository.Create(ClassModel.GenerateClassDTOFromModel(model.Class));
            work.Save();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the edit page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new ClassEditViewModel()
            {
                Class = ClassModel.GenerateClassModelFromDTO(work.ClassRepository.GetDTO(id))
            };
            return View(model);
        }

        /// <summary>
        /// Edits the specified class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(ClassEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            work.ClassRepository.Update(ClassModel.GenerateClassDTOFromModel(model.Class));
            work.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the delete page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new ClassDeleteViewModel()
            {
                Class = ClassModel.GenerateClassModelFromDTO(work.ClassRepository.GetDTO(id))
            };

            return View(model);
        }

        /// <summary>
        /// Deletes the specified class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(ClassDeleteViewModel model)
        {
            work.ClassRepository.Delete(model.Class.ID);
            work.Save();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
