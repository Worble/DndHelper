using DndDmWebApp.ViewModels.Models;
using System.Collections.Generic;

namespace DndDmWebApp.ViewModels.CharacterViewModels
{
    /// <summary>
    /// The character create view model
    /// </summary>
    public class CharacterEditViewModel
    {
        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int? GameID { get; set; }

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
        public List<RaceModel> Races { get; set; }

        /// <summary>
        /// Gets or sets the classes.
        /// </summary>
        /// <value>
        /// The classes.
        /// </value>
        public List<ClassModel> Classes { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public List<BaseStatModel> BaseStats { get; set; }
    }
}