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
    /// Represents a race entity in the database 
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class Race : BaseEntity
    {
        #region data members
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        #endregion

        #region data access

        /// <summary>
        /// Gets all the races.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        internal static IEnumerable<RaceDTO> GetAll(DndDmHelperContext context)
        {
            return context.Races
                .Select(e => RaceDTO.CreateDTOFromRace(e));
        }

        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static RaceDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.Races
                .Select(e => RaceDTO.CreateDTOFromRace(e))
                .FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Updates the specified race.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="race">The race.</param>
        internal static void Update(DndDmHelperContext context, RaceDTO race)
        {
            var raceToUpdate = context.Races.Find(race.ID);
            raceToUpdate.Name = race.Name;

            context.Attach(raceToUpdate);
            context.Entry(raceToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified race.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        internal static void Delete(DndDmHelperContext context, int id)
        {
            context.Races.Remove(context.Races.Find(id));
        }

        /// <summary>
        /// Creates the specified race.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="raceDTO">The race dto.</param>
        internal static void Create(DndDmHelperContext context, RaceDTO raceDTO)
        {
            context.Races.Add(new Race() { Name = raceDTO.Name });
        }

        #endregion
    }
}
