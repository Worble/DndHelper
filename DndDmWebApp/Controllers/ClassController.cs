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
        public IActionResult Index()
        {
            var model = new ClassIndexViewModel()
            {
                Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e))
            };
            return View(model);
        }

        #endregion
    }
}
