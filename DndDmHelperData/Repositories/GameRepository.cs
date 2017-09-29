using DndDmHelperData.Context;
using DndDmHelperData.Entities;
using DndDmHelperData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories
{
    /// <summary>
    /// The game repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IGameRepository" />
    public class GameRepository : IGameRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GameRepository(DndDmHelperContext context)
        {
            this.context = context;
        }
        #endregion

        #region IGameRepository inherited methods

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="userID">The user ID.</param>
        public void Create(string name, string description, int userID)
        {
            Game.Create(context, name, description, userID);
        }

        /// <summary>
        /// Deletes the specified game.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            Game.Delete(context, id);
        }

        /// <summary>
        /// Gets all games for the specified user.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public IEnumerable<GameDTO> GetAllGamesForUser(int userID)
        {
            return Game.GetAllGamesForUser(context, userID);
        }

        /// <summary>
        /// Gets the game details for the given identifier.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        public GameDTO GetGameDetails(int gameID)
        {
            return Game.GetGame(context, gameID);
        }

        #endregion
    }
}
