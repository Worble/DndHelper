using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;

namespace DndDmHelperData.Entities
{
    public class GameCharacterBaseStat : BaseEntity
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
        public virtual GameCharacter Character { get; set; }

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

        #region data access

        internal static void Add(DndDmHelperContext context, TemplateCharacterBaseStat baseStat, GameCharacter gameCharacter)
        {
            context.GameCharacterBaseStats.Add(new GameCharacterBaseStat()
            {
                BaseStatID = baseStat.BaseStatID,
                Character = gameCharacter,
                Value = baseStat.Value
            });
        }

        #endregion
    }
}
