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
    /// The template character repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.ITemplateCharacterRepository" />
    public class TemplateCharacterRepository : ITemplateCharacterRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateCharacterRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TemplateCharacterRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region ITemplateCharacterRepository inherited methods

        /// <summary>
        /// Gets all template characters.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CharacterDTO> GetAll()
        {
            return TemplateCharacter.GetAll(context);
        }

        /// <summary>
        /// Adds the specified character.
        /// There is no need to call Save() after this method.
        /// </summary>
        /// <param name="characterDTO">The character.</param>
        public void Add(CharacterDTO characterDTO)
        {
            var character = TemplateCharacter.Add(context, characterDTO);
            foreach (var baseStat in characterDTO.BaseStats)
            {
                TemplateCharacterBaseStat.Add(context, baseStat, character);
            }
        }

        /// <summary>
        /// Gets the specified template character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CharacterDTO GetDTO(int id)
        {
            return TemplateCharacter.GetDTO(context, id);
        }

        /// <summary>
        /// Updates the specified character.
        /// </summary>
        /// <param name="characterDTO">The character dto.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(CharacterDTO characterDTO)
        {
            TemplateCharacter.Update(context, characterDTO);
        }

        /// <summary>
        /// Deletes the specified character.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TemplateCharacter.Delete(context, id);
        }

        #endregion
    }
}
