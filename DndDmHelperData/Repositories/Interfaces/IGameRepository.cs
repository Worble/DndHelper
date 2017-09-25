using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The game repository interface
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="userID">The user ID.</param>
        void Create(string name, string description, int userID);

        /// <summary>
        /// Gets all games for the specified user.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        IEnumerable<GameDTO> GetAllGamesForUser(int userID);

        /// <summary>
        /// Gets the game details for the given identifier.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        GameDTO GetGameDetails(int gameID);
    }
}
