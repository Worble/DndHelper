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
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ClassDTO> GetAll()
        {
            return Class.GetAll(context);
        }

        /// <summary>
        /// Adds the specified class.
        /// </summary>
        /// <param name="class">The class.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(ClassDTO @class)
        {
            Class.Add(context, @class);
        }

        #endregion
    }
}
