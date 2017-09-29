using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The note repository interface
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// Gets all the notes for the game.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        IEnumerable<NoteDTO> GetAllForGame(int gameID);

        /// <summary>
        /// Adds the specified note.
        /// </summary>
        /// <param name="noteDTO">The note dto.</param>
        void Add(NoteDTO noteDTO);

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        NoteDTO GetDTO(int id);

        /// <summary>
        /// Edits the specified note.
        /// </summary>
        /// <param name="noteDTO">The note dto.</param>
        void Edit(NoteDTO noteDTO);
    }
}
