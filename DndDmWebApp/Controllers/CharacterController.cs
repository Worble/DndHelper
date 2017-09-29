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
        public IActionResult Create(int? gameID)
        {
            var model = new CharacterCreateViewModel();
            model.GameID = gameID;
            PopulateLists(model);

            model.CharacterModel = new CharacterModel()
            {
                BaseStats = model.BaseStats.Where(e => e.Default),
                Skills = model.Skills.Where(e => e.Default)
            };

            foreach (var baseStat in model.CharacterModel.BaseStats)
            {
                baseStat.Value = 10;
            }

            return View(model);
        }

        /// <summary>
        /// Creates the specified character.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CharacterCreateViewModel model, string submit, string deletestat, string deleteskill)
        {
            //this is kind of an abomination (but it works)

            if (!string.IsNullOrWhiteSpace(deletestat))
            {
                var baseStats = model.CharacterModel.BaseStats.ToList();
                baseStats.Remove(baseStats[int.Parse(deletestat)]);
                model.CharacterModel.BaseStats = baseStats;
                model = PopulateLists(model);

                foreach (var modelValue in ModelState.Values)
                {
                    modelValue.Errors.Clear();
                }
                return View(model);
            }

            else if (!string.IsNullOrWhiteSpace(deleteskill))
            {
                var skills = model.CharacterModel.Skills.ToList();
                skills.Remove(skills[int.Parse(deleteskill)]);
                model.CharacterModel.Skills = skills;
                model = PopulateLists(model);


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
                    case "statadd":
                        var baseStats = model.CharacterModel.BaseStats.ToList();
                        baseStats.Add(new BaseStatModel());
                        model.CharacterModel.BaseStats = baseStats;
                        model = PopulateLists(model);

                        foreach (var modelValue in ModelState.Values)
                        {
                            modelValue.Errors.Clear();
                        }
                        return View(model);

                    case "skilladd":
                        var skills = model.CharacterModel.Skills.ToList();
                        skills.Add(new SkillModel());
                        model.CharacterModel.Skills = skills;
                        model = PopulateLists(model);

                        foreach (var modelValue in ModelState.Values)
                        {
                            modelValue.Errors.Clear();
                        }
                        return View(model);

                    case "submit":
                        if (!ModelState.IsValid)
                        {
                            model = PopulateLists(model);

                            return View(model);
                        }

                        work.TemplateCharacterRepository.Add(CharacterModel.GenerateCharacterDTOFromModel(model.CharacterModel));
                        work.Save();

                        if(model.GameID != null)
                        {
                            return RedirectToAction("AddCharacter", "Game", new { id = model.GameID });
                        }
                        return RedirectToAction("Index");

                    default:
                        model = PopulateLists(model);

                        return View(model);
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
        public IActionResult Edit(int id, int? gameID)
        {
            var model = new CharacterEditViewModel();
            model.GameID = gameID;
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

            if (model.GameID != null)
            {
                return RedirectToAction("AddCharacter", "Game", new { id = model.GameID });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id, int? gameID)
        {
            var model = new CharacterDeleteViewModel();
            model.GameID = gameID;
            model.CharacterModel = CharacterModel.GenerateCharacterModelFromDTO(work.TemplateCharacterRepository.GetDTO(id));
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(CharacterDeleteViewModel model)
        {
            work.TemplateCharacterRepository.Delete(model.CharacterModel.ID);
            work.Save();

            if (model.GameID != null)
            {
                return RedirectToAction("AddCharacter", "Game", new { id = model.GameID });
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

        private CharacterCreateViewModel PopulateLists(CharacterCreateViewModel model)
        {
            model.Races = work.RaceRepository.GetAll().Select(e => RaceModel.GenerateRaceModelFromDTO(e)).ToList();
            model.Classes = work.ClassRepository.GetAll().Select(e => ClassModel.GenerateClassModelFromDTO(e)).ToList();
            model.BaseStats = work.BaseStatRepository.GetAll().Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)).ToList();
            model.Skills = work.SkillRepository.GetAll().Select(e => SkillModel.GenerateSkillModelFromDTO(e));

            return model;
        }
    }
}
