using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.CharacterViewModels
{
    /// <summary>
    /// The character index view model.
    /// </summary>
    public class CharacterIndexViewModel
    {
        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public List<CharacterModel> Characters { get; set; }
    }
}
