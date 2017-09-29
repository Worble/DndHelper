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
    /// Represents a game entity in the database
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class Game : BaseEntity
    {
        #region Data members        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public int OwnerID { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public virtual ICollection<GameCharacter> Characters { get; set; }

        #endregion

        #region data access

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gameID">The game identifier.</param>
        /// <returns></returns>
        internal static GameDTO GetGame(DndDmHelperContext context, int gameID)
        {
            return context.Games
                .Include(e => e.Characters)
                    .ThenInclude(e => e.Race)
                .Include(e => e.Characters)
                    .ThenInclude(e => e.Class)
                .Select(e => GameDTO.GenerateDTOFromGame(e))
                .FirstOrDefault(e => e.ID == gameID);
        }

        /// <summary>
        /// Deletes the specified game.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        internal static void Delete(DndDmHelperContext context, int id)
        {
            context.Games.Remove(context.Games.Find(id));
        }

        /// <summary>
        /// Creates the specified game.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="userID">The user identifier.</param>
        internal static void Create(DndDmHelperContext context, string name, string description, int userID)
        {
            context.Games.Add(new Game() { Name = name, Description = description, OwnerID = userID });
        }

        /// <summary>
        /// Gets all games for user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<GameDTO> GetAllGamesForUser(DndDmHelperContext context, int userID)
        {
            return context.Games
                .Where(e => e.OwnerID == userID)
                .Include(e => e.Characters)
                .Select(e => GameDTO.GenerateDTOFromGame(e));
        }

        #endregion
    }
}
