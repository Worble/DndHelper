using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Entities;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// The skill data transfer object.
    /// </summary>
    public class SkillDTO
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
        /// Gets or sets a value indicating whether this <see cref="SkillDTO"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SkillDTO"/> is proficient.
        /// </summary>
        /// <value>
        ///   <c>true</c> if proficient; otherwise, <c>false</c>.
        /// </value>
        public bool Proficient { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The time last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        #endregion

        #region methods

        internal static SkillDTO GenerateDTOFromSkill(Skill skill)
        {
            return new SkillDTO()
            {
                ID = skill.ID,
                Name = skill.Name,
                Default = skill.Default,
                LastEdited = skill.EditedDate ?? skill.CreatedDate
            };
        }

        #endregion
    }
}
