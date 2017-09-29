using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels.Models;
using DndDmWebApp.ViewModels.NoteViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls all note webpages
    /// </summary>
    /// <seealso cref="DndDmWebApp.Controllers.BaseController" />
    public class NoteController : BaseController
    {
        #region data members and ctor
        private IUnitOfWork work;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public NoteController(IUnitOfWork work)
        {
            this.work = work;
        }

        #endregion

        #region methods

        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int gameID)
        {
            var model = new NoteIndexViewModel();
            model.GameID = gameID;
            model.Notes = work.NoteRepository.GetAllForGame(gameID).Select(e => NoteModel.GenerateNoteModelFromDTO(e));
            return View(model);
        }

        /// <summary>
        /// Displays the create page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int gameID)
        {
            var model = new NoteCreateViewModel();
            model.Note = new NoteModel()
            {
                GameID = gameID
            };
            model.NoteTypes = work.NoteTypeRepository.GetAll().Select(e => NoteTypeModel.GenerateNoteTypeModelFromDTO(e));
            return View(model);
        }

        /// <summary>
        /// Creates the specified note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(NoteCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.NoteTypes = work.NoteTypeRepository.GetAll().Select(e => NoteTypeModel.GenerateNoteTypeModelFromDTO(e));
                return View(model);
            }

            work.NoteRepository.Add(NoteModel.GenerateNoteDTOFromModel(model.Note));
            work.Save();

            return RedirectToAction("Index", new { GameID = model.Note.GameID });
        }

        /// <summary>
        /// DIsplays the edit page.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int gameID, int id)
        {
            var model = new NoteEditViewModel();
            model.Note = NoteModel.GenerateNoteModelFromDTO(work.NoteRepository.GetDTO(id));
            model.NoteTypes = work.NoteTypeRepository.GetAll().Select(e => NoteTypeModel.GenerateNoteTypeModelFromDTO(e));

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(NoteEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.NoteTypes = work.NoteTypeRepository.GetAll().Select(e => NoteTypeModel.GenerateNoteTypeModelFromDTO(e));
                return View(model);
            }

            work.NoteRepository.Edit(NoteModel.GenerateNoteDTOFromModel(model.Note));
            work.Save();

            return RedirectToAction("Index", new { gameId = model.Note.GameID });
        }

        #endregion
    }
}
