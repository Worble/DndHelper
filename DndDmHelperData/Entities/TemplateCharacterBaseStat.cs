using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Entities
{
    public class TemplateCharacterBaseStat : BaseEntity
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
        public virtual TemplateCharacter Character { get; set; }

        /// <summary>
        /// Gets or sets the base stat identifier.
        /// </summary>
        /// <value>
        /// The base stat identifier.
        /// </value>
        public int BaseStatID { get; set; }

        /// <summary>
        /// Gets or sets the base stat.
        /// </summary>
        /// <value>
        /// The base stat.
        /// </value>
        public virtual BaseStat BaseStat { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        #endregion

        #region data acess

        /// <summary>
        /// Adds the specified baseStat to the given character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="baseStat">The base stat.</param>
        /// <param name="id">The id.</param>
        /// <exception cref="NotImplementedException"></exception>
        internal static void Add(DndDmHelperContext context, BaseStatDTO baseStat, TemplateCharacter character)
        {
            context.Add(new TemplateCharacterBaseStat()
            {
                BaseStatID = baseStat.ID,
                Character = character,
                Value = baseStat.Value
            });
        }

        #endregion
    }
}
