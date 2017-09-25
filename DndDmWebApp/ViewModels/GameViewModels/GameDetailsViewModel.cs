using DndDmHelperData.DTOs;
using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.GameViewModels
{
    /// <summary>
    /// The game details view model
    /// </summary>
    public class GameDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        public GameModel Game { get; set; }
    }
}
