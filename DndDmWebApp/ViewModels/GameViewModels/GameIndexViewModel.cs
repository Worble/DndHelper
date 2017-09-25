using DndDmHelperData.DTOs;
using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.GameViewModels
{
    /// <summary>
    /// The home index view model
    /// </summary>
    public class GameIndexViewModel
    {
        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public List<GameModel> Games { get; set; }
    }
}
