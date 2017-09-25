using DndDmHelperData.DTOs;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels;
using DndDmWebApp.ViewModels.CharacterViewModels;
using DndDmWebApp.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the game webpages
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CharacterController : BaseController
    {
        #region data members and ctor
        private IUnitOfWork work;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public CharacterController(IUnitOfWork work)
        {
            this.work = work;
        }
        #endregion

        #region methods

        /// <summary>
        /// Displays the character index page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CharacterIndexViewModel();
            model.Characters = work.TemplateCharacterRepository.GetAll().Select(e => CharacterModel.GenerateCharacterModelFromDTO(e)).ToList();
            model.Characters = model.Characters.OrderBy(c => c.ID).ToList();
            return View(model);
        }

        /// <summary>
        /// Displays the create page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(string returnUrl)
        {
            var model = new CharacterCreateViewModel();
            model.ReturnUrl = returnUrl;
            model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
            model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
            model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();
            model.CharacterModel = new CharacterModel()
            {
                BaseStats = model.BaseStats.Where(e => e.Default)
            };
            return View(model);
        }

        /// <summary>
        /// Creates the specified character.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CharacterCreateViewModel model, string submit, string delete)
        {
            //this is kind of an abomination (but it works)...
            if (!string.IsNullOrWhiteSpace(delete))
            {
                var baseStats = model.CharacterModel.BaseStats.ToList();
                baseStats.Remove(baseStats[int.Parse(delete)]);
                model.CharacterModel.BaseStats = baseStats;
                model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
                model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
                model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();
                foreach (var modelValue in ModelState.Values)
                {
                    modelValue.Errors.Clear();
                }
                return View(model);
            }
            else
            {
                switch (submit)
                {
                    case "add":
                        var baseStats = model.CharacterModel.BaseStats.ToList();
                        baseStats.Add(new BaseStatModel());
                        model.CharacterModel.BaseStats = baseStats;
                        model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
                        model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
                        model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();
                        foreach (var modelValue in ModelState.Values)
                        {
                            modelValue.Errors.Clear();
                        }
                        return View(model);

                    case "submit":
                        if (!ModelState.IsValid)
                        {
                            model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
                            model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
                            model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();
                            return View(model);
                        }

                        work.TemplateCharacterRepository.Add(CharacterModel.GenerateCharacterDTOFromModel(model.CharacterModel));
                        work.Save();

                        string decodedUrl = string.Empty;
                        if (!string.IsNullOrEmpty(model.ReturnUrl))
                        {
                            decodedUrl = WebUtility.HtmlDecode(model.ReturnUrl);
                            if (Url.IsLocalUrl(decodedUrl))
                            {
                                return this.Redirect(decodedUrl);
                            }
                        }
                        return RedirectToAction("Index");

                    default:
                        return NotFound();
                }
            }
        }

        /// <summary>
        /// Displays the character edit page
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id, string returnUrl)
        {
            var model = new CharacterEditViewModel();
            model.ReturnUrl = returnUrl;
            model.CharacterModel = CharacterModel.GenerateCharacterModelFromDTO(work.TemplateCharacterRepository.GetDTO(id));
            model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
            model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
            model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();

            return View(model);
        }

        /// <summary>
        /// Edits the character.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(CharacterEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
                model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
                model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();

                return View(model);
            }

            work.TemplateCharacterRepository.Update(CharacterModel.GenerateCharacterDTOFromModel(model.CharacterModel));
            work.Save();

            string decodedUrl = string.Empty;
            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                decodedUrl = WebUtility.HtmlDecode(model.ReturnUrl);
                if (Url.IsLocalUrl(decodedUrl))
                {
                    return this.Redirect(decodedUrl);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id, string returnUrl)
        {
            var model = new CharacterDeleteViewModel();
            model.ReturnUrl = returnUrl;
            model.CharacterModel = CharacterModel.GenerateCharacterModelFromDTO(work.TemplateCharacterRepository.GetDTO(id));
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(CharacterDeleteViewModel model)
        {
            work.TemplateCharacterRepository.Delete(model.CharacterModel.ID);
            work.Save();

            string decodedUrl = string.Empty;
            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                decodedUrl = WebUtility.HtmlDecode(model.ReturnUrl);
                if (Url.IsLocalUrl(decodedUrl))
                {
                    return this.Redirect(decodedUrl);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AsyncDelete(int id)
        {
            work.TemplateCharacterRepository.Delete(id);
            work.Save();

            return Ok();
        }
        #endregion
    }
}
