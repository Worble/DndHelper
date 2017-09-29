using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The skill model.
    /// </summary>
    public class SkillModel
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SkillModel"/> is proficient.
        /// </summary>
        /// <value>
        ///   <c>true</c> if proficient; otherwise, <c>false</c>.
        /// </value>
        public bool Proficient { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SkillModel"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

        #endregion

        #region methods

        internal static SkillModel GenerateSkillModelFromDTO(SkillDTO skill)
        {
            return new SkillModel()
            {
                ID = skill.ID,
                Name = skill.Name,
                Proficient = skill.Proficient,
                Value = skill.Value,
                Default = skill.Default
            };
        }

        #endregion
    }
}
