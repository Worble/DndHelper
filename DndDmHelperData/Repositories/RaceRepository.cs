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
    /// The race repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IRaceRepository" />
    public class RaceRepository : IRaceRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RaceRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region IRaceRepository inherited methods

        /// <summary>
        /// Gets all races.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RaceDTO> GetAll()
        {
            return Race.GetAll(context);
        }

        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public RaceDTO GetDTO(int id)
        {
            return Race.GetDTO(context, id);
        }

        /// <summary>
        /// Updates the specified race.
        /// </summary>
        /// <param name="Race">The race.</param>
        public void Update(RaceDTO race)
        {
            Race.Update(context, race);
        }

        /// <summary>
        /// Creates the specified race dto.
        /// </summary>
        /// <param name="raceDTO">The race dto.</param>
        public void Create(RaceDTO raceDTO)
        {
            Race.Create(context, raceDTO);
        }

        /// <summary>
        /// Deletes the specified race.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            Race.Delete(context, id);
        }

        #endregion
    }
}
