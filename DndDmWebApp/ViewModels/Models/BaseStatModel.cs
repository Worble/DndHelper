using System;
using DndDmHelperData.DTOs;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The base stat model.
    /// </summary>
    public class BaseStatModel
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
        /// Gets or sets a value indicating whether this <see cref="BaseStatModel"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

        #endregion

        #region methods

        internal static BaseStatModel GeneralBaseStatModelFromDTO(BaseStatDTO baseStat)
        {
            return new BaseStatModel()
            {
                ID = baseStat.ID,
                Name = baseStat.Name,
                Value = baseStat.Value,
                Default = baseStat.Default
            };
        }

        internal static BaseStatDTO GenerateBaseStatDTOFromModel(BaseStatModel baseStat)
        {
            return new BaseStatDTO()
            {
                ID = baseStat.ID,
                Name = baseStat.Name,
                Value = baseStat.Value
            };
        }

        #endregion
    }
}