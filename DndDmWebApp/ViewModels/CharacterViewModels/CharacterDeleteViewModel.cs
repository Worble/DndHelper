using DndDmWebApp.ViewModels.Models;
using System.Collections.Generic;

namespace DndDmWebApp.ViewModels.CharacterViewModels
{
    /// <summary>
    /// The character create view model
    /// </summary>
    public class CharacterDeleteViewModel
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
    }
}