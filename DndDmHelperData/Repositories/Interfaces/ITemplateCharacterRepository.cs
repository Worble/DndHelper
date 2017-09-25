using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The template character repository interface.
    /// </summary>
    public interface ITemplateCharacterRepository
    {
        /// <summary>
        /// Gets all template characters.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CharacterDTO> GetAll();

        /// <summary>
        /// Adds the specified character.
        /// </summary>
        /// <param name="characterDTO">The character.</param>
        void Add(CharacterDTO characterDTO);

        /// <summary>
        /// Gets the specified template character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CharacterDTO GetDTO(int id);

        /// <summary>
        /// Updates the specified character.
        /// </summary>
        /// <param name="characterDTO">The character dto.</param>
        void Update(CharacterDTO characterDTO);

        /// <summary>
        /// Deletes the specified character.
        /// </summary>
        /// <param name="ID">The id.</param>
        void Delete(int id);
    }
}
