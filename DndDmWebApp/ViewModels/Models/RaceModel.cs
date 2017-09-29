using System;
using DndDmHelperData.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The race model
    /// </summary>
    public class RaceModel
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
        [Required(ErrorMessage = "Race name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the edited time.
        /// </summary>
        /// <value>
        /// The edited time.
        /// </value>
        [Display(Name = "Last Edited")]
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the race model from the dto.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <returns></returns>
        internal static RaceModel GenerateRaceModelFromDTO(RaceDTO race)
        {
            return new RaceModel()
            {
                ID = race.ID,
                Name = race.Name,
                LastEdited = race.LastEdited
            };
        }

        /// <summary>
        /// Generates the race dto from model.
        /// </summary>
        /// <param name="race">The race.</param>
        /// <returns></returns>
        internal static RaceDTO GenerateRaceDTOFromModel(RaceModel race)
        {
            return new RaceDTO()
            {
                ID = race.ID,
                Name = race.Name
            };
        }
        #endregion

    }
}