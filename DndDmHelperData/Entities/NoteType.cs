using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using System.Linq;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a note type entity in the database
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class NoteType : BaseEntity
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

        internal static IEnumerable<NoteTypeDTO> GetAll(DndDmHelperContext context)
        {
            return context.NoteTypes.Select(e => NoteTypeDTO.GenerateDTOFromNoteType(e));
        }

        #endregion
    }
}
