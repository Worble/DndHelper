using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The note type repository interface
    /// </summary>
    public interface INoteTypeRepository
    {
        /// <summary>
        /// Gets all the note types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<NoteTypeDTO> GetAll();
    }
}
