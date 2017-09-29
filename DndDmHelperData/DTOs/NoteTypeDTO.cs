using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// The note type data transfer object.
    /// </summary>
    public class NoteTypeDTO
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
        /// Gets or sets the last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the note dto from the note.
        /// </summary>
        /// <param name="noteType">The notetype.</param>
        /// <returns></returns>
        internal static NoteTypeDTO GenerateDTOFromNoteType(NoteType noteType)
        {
            return new NoteTypeDTO()
            {
                ID = noteType.ID,
                Name = noteType.Name,
                LastEdited = noteType.EditedDate ?? noteType.CreatedDate
            };
        }

        #endregion

    }
}
