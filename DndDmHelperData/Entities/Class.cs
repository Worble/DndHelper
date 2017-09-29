using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Creates the specified class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="classDTO">The class dto.</param>
        internal static void Create(DndDmHelperContext context, ClassDTO classDTO)
        {
            context.Classes.Add(new Class() { Name = classDTO.Name });
        }

        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static ClassDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.Classes
                .Select(e => ClassDTO.CreateDTOFromClass(e))
                .FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Deletes the specified class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The class id.</param>
        internal static void Delete(DndDmHelperContext context, int id)
        {
            context.Classes.Remove(context.Classes.Find(id));
        }

        /// <summary>
        /// Edits the specified class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="classDTO">The class dto.</param>
        internal static void Update(DndDmHelperContext context, ClassDTO classDTO)
        {
            var classToUpdate = context.Classes.Find(classDTO.ID);
            classToUpdate.Name = classDTO.Name;

            context.Attach(classToUpdate);
            context.Entry(classToUpdate).State = EntityState.Modified;
        }

        #endregion
    }
}
