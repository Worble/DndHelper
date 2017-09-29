using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DndDmHelperData.DTOs
{
    /// <summary>
    /// Represents the character data transfer object.
    /// </summary>
    public class CharacterDTO
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
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public RaceDTO Race { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public ClassDTO Class { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public IEnumerable<BaseStatDTO> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets the game identifier (if the character belongs to one).
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameID { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the template character DTO from the character entity.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public static CharacterDTO GenerateDTOFromTemplateCharacter(TemplateCharacter character)
        {
            return new CharacterDTO()
            {
                ID = character.ID,
                Name = character.Name,
                Description = character.Description,
                Level = character.Level,
                Race = character.Race != null ? RaceDTO.CreateDTOFromRace(character.Race) : null,
                Class = character.Race != null ? ClassDTO.CreateDTOFromClass(character.Class) : null,
                LastEdited = character.EditedDate ?? character.CreatedDate,
                BaseStats = character.BaseStats != null ? character.BaseStats.Select(e => BaseStatDTO.GenerateDTOFromTemplateBaseStat(e)) : null
            };
        }

        /// <summary>
        /// Generates the dto from the game character entity.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public static CharacterDTO GenerateDTOFromGameCharacter(GameCharacter character)
        {
            return new CharacterDTO()
            {
                ID = character.ID,
                Name = character.Name,
                Description = character.Description,
                Level = character.Level,
                Race = character.Race != null ? RaceDTO.CreateDTOFromRace(character.Race) : null,
                Class = character.Race != null ? ClassDTO.CreateDTOFromClass(character.Class) : null,
                LastEdited = character.EditedDate ?? character.CreatedDate,
                BaseStats = character.BaseStats != null ? character.BaseStats.Select(e => BaseStatDTO.GenerateDTOFromGameBaseStat(e)) : null,
                GameID = character.GameID
            };
        }

        #endregion
    }
}