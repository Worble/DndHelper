using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.DiceViewModels
{
    /// <summary>
    /// The roll index view model.
    /// </summary>
    public class DiceIndexViewModel
    {
        /// <summary>
        /// Gets or sets the dice amount.
        /// </summary>
        /// <value>
        /// The dice amount.
        /// </value>
        [Range(0, 255, ErrorMessage = "Please use between 0 and 255 dice.")]
        public int DiceAmount { get; set; }

        /// <summary>
        /// Gets or sets the size of the dice.
        /// </summary>
        /// <value>
        /// The size of the dice.
        /// </value>
        [Range(0, 255, ErrorMessage = "Please use a dice with sides between 0 and 255.")]
        public int DiceSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RollIndexViewModel"/> is add.
        /// </summary>
        /// <value>
        ///   <c>true</c> if add; otherwise, <c>false</c>.
        /// </value>
        public bool Add { get; set; }

        /// <summary>
        /// Gets or sets the plus or minus amount.
        /// </summary>
        /// <value>
        /// The plus or minus amount.
        /// </value>
        [Range(0, 255, ErrorMessage = "Please add or subtract between 0 and 255")]
        public int PlusMinusAmount { get; set; }

        /// <summary>
        /// Gets or sets the Results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public List<int> Results { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int? Total { get; set; }
    }
}
