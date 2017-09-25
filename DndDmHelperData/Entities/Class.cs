using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a class entity in the database
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class Class : BaseEntity
    {
        #region data members
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        #endregion

        #region data access

        /// <summary>
        /// Gets all the classes
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static IEnumerable<ClassDTO> GetAll(DndDmHelperContext context)
        {
            return context.Classes
                .Select(e => ClassDTO.CreateDTOFromClass(e));
        }

        /// <summary>
        /// Adds the specified class.
        /// </summary>
        /// <param name="class">The class.</param>
        internal static void Add(DndDmHelperContext context, ClassDTO @class)
        {
            context.Classes.Add(new Class() { Name = @class.Name });
        }

        #endregion
    }
}
