using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Entities;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// Represents the class data transfer object.
    /// </summary>
    public class ClassDTO
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
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Creates the class dto from class entity.
        /// </summary>
        /// <param name="class">The class.</param>
        /// <returns></returns>
        internal static ClassDTO CreateDTOFromClass(Class @class)
        {
            return new ClassDTO() { ID = @class.ID, Name = @class.Name, LastEdited = @class.EditedDate ?? @class.CreatedDate };
        }

        #endregion
    }
}
