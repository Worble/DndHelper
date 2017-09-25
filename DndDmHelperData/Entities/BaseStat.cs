using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represent a base stat in the database.
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class BaseStat : BaseEntity
    {
        #region data members
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseStat"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

        #endregion

        #region data access

        internal static IEnumerable<BaseStatDTO> GetAll(DndDmHelperContext context)
        {
            return context.BaseStats.Select(e => BaseStatDTO.GenerateDTOFromEntity(e));
        }

        #endregion
    }
}
