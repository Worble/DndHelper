using DndDmHelperData.DTOs;
using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.GameViewModels
{
    /// <summary>
    /// The game add character view model
    /// </summary>
    public class GameAddCharacterViewModel
    {
        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameID { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public List<CharacterModel> Characters { get; set; }
    }
}
