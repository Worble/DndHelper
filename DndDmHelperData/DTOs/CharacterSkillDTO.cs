using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// The character skill data transfer object.
    /// </summary>
    public class CharacterSkillDTO
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
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillID { get; set; }

        /// <summary>
        /// Gets or sets the skill.
        /// </summary>
        /// <value>
        /// The skill.
        /// </value>
        public SkillDTO Skill { get; set; }

        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>
        /// The character.
        /// </value>
        public CharacterDTO Character { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CharacterSkillDTO"/> is proficient.
        /// </summary>
        /// <value>
        ///   <c>true</c> if proficient; otherwise, <c>false</c>.
        /// </value>
        public bool Proficient { get; set; }

        /// <summary>
        /// Gets or sets the last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        #endregion
    }
}
