using System;
using DndDmHelperData.Entities;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// Represents the base stat data transport object.
    /// </summary>
    public class BaseStatDTO
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
        /// Gets or sets a value indicating whether this <see cref="BaseStatDTO"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

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
        /// Generates the dto from template base stat.
        /// </summary>
        /// <param name="baseStat">The base stat.</param>
        /// <returns></returns>
        public static BaseStatDTO GenerateDTOFromTemplateBaseStat(TemplateCharacterBaseStat baseStat)
        {
            return new BaseStatDTO()
            {
                ID = baseStat.BaseStatID,
                Name = baseStat.BaseStat.Name,
                Value = baseStat.Value,
                LastEdited = baseStat.EditedDate ?? baseStat.CreatedDate
            };
        }

        /// <summary>
        /// Generates the dto from entity.
        /// </summary>
        /// <param name="baseStat">The base stat.</param>
        /// <returns></returns>
        internal static BaseStatDTO GenerateDTOFromEntity(BaseStat baseStat)
        {
            return new BaseStatDTO()
            {
                ID = baseStat.ID,
                Name = baseStat.Name,
                Default = baseStat.Default,
                LastEdited = baseStat.EditedDate ?? baseStat.CreatedDate
            };
        }

        /// <summary>
        /// Generates the dto from game base stat.
        /// </summary>
        /// <param name="baseStat">The base stat.</param>
        /// <returns></returns>
        public static BaseStatDTO GenerateDTOFromGameBaseStat(GameCharacterBaseStat baseStat)
        {
            return new BaseStatDTO()
            {
                ID = baseStat.BaseStatID,
                Name = baseStat.BaseStat.Name,
                Value = baseStat.Value,
                LastEdited = baseStat.EditedDate ?? baseStat.CreatedDate
            };
        }

        internal static TemplateCharacterBaseStat GenerateEntityFromDTO(BaseStatDTO e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}