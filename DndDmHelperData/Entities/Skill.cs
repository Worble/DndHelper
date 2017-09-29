using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a skill entity in the database.
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class Skill : BaseEntity
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
        /// Gets or sets a value indicating whether this <see cref="Skill"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }
        #endregion

        #region data access

        internal static IEnumerable<SkillDTO> GetAll(DndDmHelperContext context)
        {
            return context.Skills
                .Select(e => SkillDTO.GenerateDTOFromSkill(e));
        }

        #endregion
    }
}
