using DndDmWebApp.ViewModels.DiceViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.Controllers
{
    /// <summary>
    /// Controls the dice roll pages.
    /// </summary>
    public class DiceController : BaseController
    {
        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = new DiceIndexViewModel()
            {
                DiceAmount = 1,
                Add = true,
                DiceSize = 20,
                PlusMinusAmount = 0
            };
            return View(model);
        }

        /// <summary>
        /// Rolls the dice.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(DiceIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Random rnd = new Random();
            model.Results = new List<int>();
            model.Total = 0;

            for (int i = 0; i < model.DiceAmount; i++)
            {
                int roll = rnd.Next(1, model.DiceSize + 1);
                model.Results.Add(roll);
                model.Total += roll;
            }

            var addition = model.PlusMinusAmount;

            if (!model.Add)
            {
                addition *= -1;
            }

            model.Total += addition;
            return View(model);
        }
    }
}
