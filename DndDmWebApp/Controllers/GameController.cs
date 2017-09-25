using DndDmHelperData.DTOs;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels;
using DndDmWebApp.ViewModels.GameViewModels;
using DndDmWebApp.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the game webpages
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class GameController : BaseController
    {
        #region data members and ctor
        private IUnitOfWork work;

        public GameController(IUnitOfWork work)
        {
            this.work = work;
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns the index page of home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new GameIndexViewModel();
            model.Games = work.GameRepository.GetAllGamesForUser(CurrentUser.ID)
                .Select(e => GameModel.GenerateGameModelFromDTO(e))
                .ToList();
            return View(model);
        }

        /// <summary>
        /// Displays the create page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new GameCreateViewModel());
        }

        /// <summary>
        /// Creates the game.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(GameCreateViewModel model)
        {
            work.GameRepository.Create(model.Name, model.Description, CurrentUser.ID);
            work.Save();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Display the game detail page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = new GameDetailsViewModel()
            {
                Game = GameModel.GenerateGameModelFromDTO(work.GameRepository.GetGameDetails(id))
            };
            return View(model);
        }

        /// <summary>
        /// Displays the add character page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCharacter(int id)
        {
            var model = new GameAddCharacterViewModel();
            model.GameID = id;
            model.Characters = work.TemplateCharacterRepository.GetAll().Select(e => CharacterModel.GenerateCharacterModelFromDTO(e)).ToList();
            model.Characters = model.Characters.OrderBy(e => e.ID).ToList();
            return View(model);
        }

        /// <summary>
        /// Adds the character.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCharacter(GameAddCharacterViewModel model)
        {
            List<int> characterIDsToAdd = new List<int>();
            foreach (var item in model.Characters)
            {
                if (item.AddToGame)
                {
                    characterIDsToAdd.Add(item.ID);
                }
            }
            work.GameCharacterRepository.Add(model.GameID, characterIDsToAdd);
            work.Save();
            return RedirectToAction("Detail", new { id = model.GameID });
        }

        [HttpGet]
        public IActionResult CharacterDetail(int id)
        {
            var model = new GameCharacterDetailViewModel()
            {
                Character = CharacterModel.GenerateCharacterModelFromDTO(work.GameCharacterRepository.GetDTO(id))
            };
            model.GameID = model.Character.GameID;
            return View(model);
        }


        #endregion
    }
}
