using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.ClassViewModels
{
    /// <summary>
    /// The class index view model.
    /// </summary>
    public class ClassIndexViewModel
    {
        /// <summary>
        /// Gets or sets the classes.
        /// </summary>
        /// <value>
        /// The classes.
        /// </value>
        public IEnumerable<ClassModel> Classes { get; set; }
    }
}
