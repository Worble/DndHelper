using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a Game Character Skill entity in the database.
    /// </summary>
    public class GameCharacterSkill : BaseEntity
    {
        #region data members

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
        public GameCharacter Character { get; set; }

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
        public Skill Skill { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameCharacterSkill"/> is proficient.
        /// </summary>
        /// <value>
        ///   <c>true</c> if proficient; otherwise, <c>false</c>.
        /// </value>
        public bool Proficient { get; set; }

        #endregion
    }
}
