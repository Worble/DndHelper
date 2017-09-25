using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.RaceViewModels
{
    /// <summary>
    /// The race index view model
    /// </summary>
    public class RaceIndexViewModel
    {
        /// <summary>
        /// Gets or sets the races.
        /// </summary>
        /// <value>
        /// The races.
        /// </value>
        public IEnumerable<RaceModel> Races { get; set; }
    }
}
