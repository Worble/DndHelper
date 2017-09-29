using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Entities;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// Represents the race data transfer object.
    /// </summary>
    public class RaceDTO
    {
        #region data members
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Creates the race dto from race entity.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <returns></returns>
        internal static RaceDTO CreateDTOFromRace(Race race)
        {
            return new RaceDTO()
            {
                ID = race.ID,
                Name = race.Name,
                LastEdited = race.EditedDate ?? race.CreatedDate
            };
        }

        #endregion
    }
}
