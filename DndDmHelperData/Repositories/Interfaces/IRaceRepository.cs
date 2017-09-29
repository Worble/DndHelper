using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The race repository interface
    /// </summary>
    public interface IRaceRepository
    {
        /// <summary>
        /// Gets all races.
        /// </summary>
        /// <returns></returns>
        IEnumerable<RaceDTO> GetAll();

        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        RaceDTO GetDTO(int id);

        /// <summary>
        /// Updates the specified race.
        /// </summary>
        /// <param name="Race">The race.</param>
        void Update(RaceDTO race);

        /// <summary>
        /// Creates the specified race dto.
        /// </summary>
        /// <param name="raceDTO">The race dto.</param>
        void Create(RaceDTO raceDTO);

        /// <summary>
        /// Deletes the specified race.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);
    }
}
