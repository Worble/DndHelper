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
    /// Represents a character entity in the database
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class GameCharacter : BaseEntity
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceID { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public virtual Race Race { get; set; }

        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public int ClassID { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public virtual Class Class { get; set; }

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
        /// The games.
        /// </value>
        public virtual Game Game { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public virtual ICollection<GameCharacterBaseStat> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public ICollection<GameCharacterSkill> Skills { get; set; }
        #endregion

        #region data access

        /// <summary>
        /// Adds the specified character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="templateCharacter">The character to add.</param>
        internal static GameCharacter Add(DndDmHelperContext context, TemplateCharacter templateCharacter, int gameID)
        {
            var characterToAdd = new GameCharacter()
            {
                Name = templateCharacter.Name,
                Description = templateCharacter.Description,
                Level = templateCharacter.Level,
                ClassID = templateCharacter.ClassID,
                RaceID = templateCharacter.RaceID,
                GameID = gameID
            };
            context.GameCharacters.Add(characterToAdd);
            return characterToAdd;
        }

        /// <summary>
        /// Gets the game character dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static CharacterDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.GameCharacters
                .Include(e => e.Race)
                .Include(e => e.Class)
                .Include(e => e.BaseStats)
                    .ThenInclude(e => e.BaseStat)
                .Select(e => CharacterDTO.GenerateDTOFromGameCharacter(e))
                .FirstOrDefault(e => e.ID == id);
        }

        #endregion
    }
}
