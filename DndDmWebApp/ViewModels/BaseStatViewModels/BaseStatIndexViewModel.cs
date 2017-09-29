using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.BaseStatViewModels
{
    /// <summary>
    /// The base stat index view model
    /// </summary>
    public class BaseStatIndexViewModel
    {
        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public IEnumerable<BaseStatModel> BaseStats { get; set; }
    }
}
