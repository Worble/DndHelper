using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents the base entity that all other entities inherit from
    /// </summary>
    public abstract class BaseEntity
    {
        #region Data members
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the date the entity was created.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date the entity was edited.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime? EditedDate { get; set; }
        #endregion
    }
}
