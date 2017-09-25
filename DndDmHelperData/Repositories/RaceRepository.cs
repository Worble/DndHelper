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
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<RaceDTO> GetAll()
        {
            return Race.GetAll(context);
        }


        #endregion
    }
}
