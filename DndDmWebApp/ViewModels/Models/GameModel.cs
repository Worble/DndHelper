using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The game model
    /// </summary>
    public class GameModel
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
        [Required(ErrorMessage = "Game name is required")]
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
        [Display(Name="Last Edited")]
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public IEnumerable<CharacterModel> Characters { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the game model from the dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        internal static GameModel GenerateGameModelFromDTO(GameDTO dto)
        {
            return new GameModel()
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                LastEdited = dto.LastEdited,
                Characters = dto.Characters != null ? dto.Characters.Select(c => CharacterModel.GenerateCharacterModelFromDTO(c)) : null
            };
        }

        #endregion
    }
}
