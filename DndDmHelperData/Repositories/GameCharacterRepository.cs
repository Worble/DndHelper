using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using DndDmHelperData.Entities;
using DndDmHelperData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Repositories
{
    /// <summary>
    /// The game character repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IGameCharacterRepository" />
    public class GameCharacterRepository : IGameCharacterRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCharacterRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GameCharacterRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region IGameCharacterRepository inherited methods

        /// <summary>
        /// Adds the specified template characters to the given game.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <param name="characterIDsToAdd">The character ids to add.</param>
        public void Add(int gameID, List<int> characterIDsToAdd)
        {
            foreach (var id in characterIDsToAdd)
            {
                var templateCharacter = TemplateCharacter.Get(context, id);
                var gameCharacter = GameCharacter.Add(context, templateCharacter, gameID);
                foreach (var baseStat in templateCharacter.BaseStats)
                {
                    GameCharacterBaseStat.Add(context, baseStat, gameCharacter);
                }
            }
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CharacterDTO GetDTO(int id)
        {
            return GameCharacter.GetDTO(context, id);
        }

        #endregion
    }
}
