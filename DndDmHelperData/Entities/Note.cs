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
    /// Represents a note entity in the database
    /// </summary>
    public class Note : BaseEntity
    {
        #region data members

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
        public NoteType NoteType { get; set; }

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
        public Game Game { get; set; }

        #endregion

        #region data access

        /// <summary>
        /// Gets all notes for the game.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<NoteDTO> GetAllForGame(DndDmHelperContext context, int gameID)
        {
            return context.Notes
                .Include(e => e.NoteType)
                .Where(e => e.GameID == gameID)
                .Select(e => NoteDTO.GenerateDTOFromNote(e));
        }

        /// <summary>
        /// Edits the specified note.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="noteDTO">The note dto.</param>
        internal static void Edit(DndDmHelperContext context, NoteDTO noteDTO)
        {
            var noteToEdit = context.Notes.Find(noteDTO.ID);
            noteToEdit.Name = noteDTO.Name;
            noteToEdit.Content = noteDTO.Content;
            noteToEdit.NoteTypeID = noteDTO.NoteTypeID;

            context.Attach(noteToEdit);
            context.Entry(noteToEdit).State = EntityState.Modified;
        }

        /// <summary>
        /// Adds the specified note dto.
        /// </summary>
        /// <param name="noteDTO">The note dto.</param>
        internal static void Add(DndDmHelperContext context, NoteDTO noteDTO)
        {
            context.Add(new Note()
            {
                Name = noteDTO.Name,
                Content = noteDTO.Content,
                GameID = noteDTO.GameID,
                NoteTypeID = noteDTO.NoteTypeID
            });
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static NoteDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.Notes
                .Include(e => e.NoteType)
                .Select(e => NoteDTO.GenerateDTOFromNote(e))
                .FirstOrDefault(e => e.ID == id);
        }

        #endregion
    }
}
