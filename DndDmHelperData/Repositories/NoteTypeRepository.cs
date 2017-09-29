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
    /// The note type repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.INoteTypeRepository" />
    public class NoteTypeRepository : INoteTypeRepository
    {
        #region data members and ctor

        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteTypeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NoteTypeRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region INoteTypeRepository inherited members

        /// <summary>
        /// Gets all the note types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NoteTypeDTO> GetAll()
        {
            return NoteType.GetAll(context);
        }


        #endregion
    }
}
