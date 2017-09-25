using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a race entity in the database 
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class Race : BaseEntity
    {
        #region data members
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        #endregion

        #region data access

        /// <summary>
        /// Gets all the races.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static IEnumerable<RaceDTO> GetAll(DndDmHelperContext context)
        {
            return context.Races
                .Select(e => RaceDTO.CreateDTOFromRace(e));
        }

        #endregion
    }
}
