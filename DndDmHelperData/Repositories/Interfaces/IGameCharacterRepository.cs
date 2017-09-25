using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The game character repository interface
    /// </summary>
    public interface IGameCharacterRepository
    {
        /// <summary>
        /// Adds the specified template characters to the given game.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <param name="characterIDsToAdd">The character ids to add.</param>
        void Add(int gameID, List<int> characterIDsToAdd);

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CharacterDTO GetDTO(int id);
    }
}
