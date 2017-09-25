using System;
using DndDmWebApp.ViewModels.Models;

namespace DndDmWebApp.ViewModels.GameViewModels
{
	/// <summary>
    /// The game character detail view model.
    /// </summary>
    public class GameCharacterDetailViewModel
    {
        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>
        /// The character.
        /// </value>
        public CharacterModel Character { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameID { get; set; }
    }

}