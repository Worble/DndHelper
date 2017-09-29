using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// The note data transfer object.
    /// </summary>
    public class NoteDTO
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
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Gets or sets the note type identifier.
        /// </summary>
        /// <value>
        /// The note type identifier.
        /// </value>
        public int NoteTypeID { get; set; }

        /// <summary>
        /// Gets or sets the type of the note.
        /// </summary>
        /// <value>
        /// The type of the note.
        /// </value>
        public NoteTypeDTO NoteType { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameID { get; set; }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        public GameDTO Game { get; set; }
        #endregion

        #region methods

        internal static NoteDTO GenerateDTOFromNote(Note note)
        {
            return new NoteDTO()
            {
                ID = note.ID,
                Name = note.Name,
                Content = note.Content,
                NoteTypeID = note.NoteTypeID,
                NoteType = note.NoteType != null ? NoteTypeDTO.GenerateDTOFromNoteType(note.NoteType) : null,
                GameID = note.GameID,
                Game = note.Game != null ? GameDTO.GenerateDTOFromGame(note.Game) : null,
                LastEdited = note.EditedDate ?? note.CreatedDate
            };
        }

        #endregion
    }
}
