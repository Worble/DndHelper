using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;
using DndDmHelperData.Entities;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The class repository interface
    /// </summary>
    public interface IClassRepository
    {
        /// <summary>
        /// Gets all the classes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ClassDTO> GetAll();

        /// <summary>
        /// Adds the specified class.
        /// </summary>
        /// <param name="class">The class.</param>
        void Add(ClassDTO @class);
    }
}
