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

        /// <summary>
        /// Creates the specified class.
        /// </summary>
        /// <param name="classDTO">The class dto.</param>
        void Create(ClassDTO classDTO);

        /// <summary>
        /// Gets the class dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ClassDTO GetDTO(int id);

        /// <summary>
        /// Edits the specified class.
        /// </summary>
        /// <param name="classDTO">The class dto.</param>
        void Update(ClassDTO classDTO);

        /// <summary>
        /// Deletes the specified class.
        /// </summary>
        /// <param name="id">The id.</param>
        void Delete(int id);
    }
}
