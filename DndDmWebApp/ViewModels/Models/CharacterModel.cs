using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The character model
    /// </summary>
    public class CharacterModel
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
        [Required(ErrorMessage = "Name is required.")]
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
        [Required(ErrorMessage = "Level is required.")]
        [Range(1, 255, ErrorMessage = "Please use a number between 1 and 255")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        [Required(ErrorMessage = "Race is required")]
        public int RaceID { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        [Required(ErrorMessage = "Class is required")]
        public int ClassID { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public RaceModel Race { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public ClassModel Class { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        [Display(Name = "Last Edited")]
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        [Display(Name = "Base Stats")]
        public IEnumerable<BaseStatModel> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [add to game].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [add to game]; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Add")]
        public bool AddToGame { get; set; }

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
        /// Generates the character model from the dto.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        internal static CharacterModel GenerateCharacterModelFromDTO(CharacterDTO character)
        {
            return new CharacterModel()
            {
                ID = character.ID,
                Description = character.Description,
                Name = character.Name,
                LastEdited = character.LastEdited,
                Level = character.Level,
                Class = character.Class != null ? ClassModel.GenerateClassModelFromDTO(character.Class) : null,
                Race = character.Race != null ? RaceModel.GenerateRaceModelFromDTO(character.Race) : null,
                BaseStats = character.BaseStats != null ? character.BaseStats.Select(e => BaseStatModel.GeneralBaseStatModelFromDTO(e)) : null,
                ClassID = character.Class != null ? character.Class.ID : 0,
                RaceID = character.Race != null ? character.Race.ID : 0,
                GameID = character.GameID

            };
        }

        internal static CharacterDTO GenerateCharacterDTOFromModel(CharacterModel character)
        {
            return new CharacterDTO()
            {
                ID = character.ID,
                Name = character.Name,
                Description = character.Description,
                Level = character.Level,
                Race = new RaceDTO() { ID = character.RaceID },
                Class = new ClassDTO() { ID = character.ClassID },
                BaseStats = character.BaseStats.Select(e => BaseStatModel.GenerateBaseStatDTOFromModel(e))
            };
        }

        #endregion
    }
}
