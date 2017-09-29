using DndDmWebApp.ViewModels.Models;
using System.Collections.Generic;

namespace DndDmWebApp.ViewModels.CharacterViewModels
{
    /// <summary>
    /// The character create view model
    /// </summary>
    public class CharacterCreateViewModel
    {
        /// <summary>
        /// Gets or sets the character model.
        /// </summary>
        /// <value>
        /// The character model.
        /// </value>
        public CharacterModel CharacterModel { get; set; }

        /// <summary>
        /// Gets or sets the races.
        /// </summary>
        /// <value>
        /// The races.
        /// </value>
        public IEnumerable<RaceModel> Races { get; set; }

        /// <summary>
        /// Gets or sets the classes.
        /// </summary>
        /// <value>
        /// The classes.
        /// </value>
        public IEnumerable<ClassModel> Classes { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public IEnumerable<BaseStatModel> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public IEnumerable<SkillModel> Skills { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int? GameID { get; set; }
    }
}