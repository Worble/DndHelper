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
    }
}
