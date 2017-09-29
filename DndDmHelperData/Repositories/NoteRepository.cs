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
    /// The note repository
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NoteRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region INoteRepository inherited methods

        /// <summary>
        /// Gets all the notes for the game.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        public IEnumerable<NoteDTO> GetAllForGame(int gameID)
        {
            return Note.GetAllForGame(context, gameID);
        }

        /// <summary>
        /// Adds the specified note.
        /// </summary>
        /// <param name="noteDTO">The note dto.</param>
        public void Add(NoteDTO noteDTO)
        {
            Note.Add(context, noteDTO);
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public NoteDTO GetDTO(int id)
        {
            return Note.GetDTO(context, id);
        }

        /// <summary>
        /// Edits the specified note.
        /// </summary>
        /// <param name="noteDTO">The note dto.</param>
        public void Edit(NoteDTO noteDTO)
        {
            Note.Edit(context, noteDTO);
        }

        #endregion
    }
}
