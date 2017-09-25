using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// Represents the game data transfer object.
    /// </summary>
    public class GameDTO
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public IEnumerable<CharacterDTO> Characters { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the gameDTO from the game entity.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        public static GameDTO GenerateDTOFromGame(Game game)
        {
            return new GameDTO()
            {
                ID = game.ID,
                Description = game.Description,
                Name = game.Name,
                Characters = game.Characters != null ? game.Characters.Select(e => CharacterDTO.GenerateDTOFromGameCharacter(e)) : null,
                LastEdited = game.EditedDate ?? game.CreatedDate
            };
        }

        #endregion
    }
}
