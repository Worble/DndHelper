using DndDmHelperData.Context;
using DndDmHelperData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;
using DndDmHelperData.Entities;

namespace DndDmHelperData.Repositories
{
    /// <summary>
    /// The class repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IClassRepository" />
    public class ClassRepository : IClassRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ClassRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region IClassRepository inherited methods

        /// <summary>
        /// Gets all the classes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClassDTO> GetAll()
        {
            return Class.GetAll(context);
        }

        /// <summary>
        /// Adds the specified class.
        /// </summary>
        /// <param name="class">The class.</param>
        public void Add(ClassDTO @class)
        {
            Class.Add(context, @class);
        }

        /// <summary>
        /// Creates the specified class.
        /// </summary>
        /// <param name="classDTO">The class dto.</param>
        public void Create(ClassDTO classDTO)
        {
            Class.Create(context, classDTO);
        }

        /// <summary>
        /// Gets the class dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ClassDTO GetDTO(int id)
        {
            return Class.GetDTO(context, id);
        }

        /// <summary>
        /// Edits the specified class.
        /// </summary>
        /// <param name="classDTO">The class dto.</param>
        public void Update(ClassDTO classDTO)
        {
            Class.Update(context, classDTO);
        }

        /// <summary>
        /// Deletes the specified class.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            Class.Delete(context, id);
        }

        #endregion
    }
}
