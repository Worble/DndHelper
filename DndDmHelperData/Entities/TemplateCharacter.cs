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
    /// Represents a template character entity in the database
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class TemplateCharacter : BaseEntity
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
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public ICollection<TemplateCharacterBaseStat> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public ICollection<TemplateCharacterSkill> Skills { get; set; }

        #endregion

        #region data access

        /// <summary>
        /// Gets all the template characters.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        internal static IEnumerable<CharacterDTO> GetAll(DndDmHelperContext context)
        {
            return context.TemplateCharacters
                .Include(e => e.Race)
                .Include(e => e.Class)
                .Select(e => CharacterDTO.GenerateDTOFromTemplateCharacter(e));
        }

        /// <summary>
        /// Deletes the specified character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        internal static void Delete(DndDmHelperContext context, int id)
        {
            context.TemplateCharacters.Remove(context.TemplateCharacters.Find(id));
        }

        /// <summary>
        /// Updates the specified character.
        /// </summary>
        /// <param name="characterDTO">The character to update.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        internal static void Update(DndDmHelperContext context, CharacterDTO characterDTO)
        {
            var character = context.TemplateCharacters.Find(characterDTO.ID);

            character.Name = characterDTO.Name;
            character.Description = characterDTO.Description;
            character.Level = characterDTO.Level;
            character.ClassID = characterDTO.Class.ID;
            character.RaceID = characterDTO.Race.ID;

            context.Attach(character);
            context.Entry(character).State = EntityState.Modified;
        }

        /// <summary>
        /// Adds the specified template character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="characterDTO">The character dto.</param>
        internal static TemplateCharacter Add(DndDmHelperContext context, CharacterDTO characterDTO)
        {
            var character = new TemplateCharacter()
            {
                Name = characterDTO.Name,
                Description = characterDTO.Description,
                Level = characterDTO.Level,
                ClassID = characterDTO.Class.ID,
                RaceID = characterDTO.Race.ID
            };
            context.TemplateCharacters.Add(character);
            return character;

        }

        /// <summary>
        /// Gets the specified template character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static TemplateCharacter Get(DndDmHelperContext context, int id)
        {
            return context.TemplateCharacters
                .Include(e => e.BaseStats)
                    .ThenInclude(e => e.BaseStat)
                .FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Gets the specified template character.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static CharacterDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.TemplateCharacters
                .Include(e => e.Race)
                .Include(e => e.Class)
                .Include(e => e.BaseStats)
                    .ThenInclude(e => e.BaseStat)
                .Select(e => CharacterDTO.GenerateDTOFromTemplateCharacter(e))
                .FirstOrDefault(e => e.ID == id);
        }

        #endregion
    }
}
