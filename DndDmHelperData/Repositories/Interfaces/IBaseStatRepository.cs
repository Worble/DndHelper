using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The base stat repository interface.
    /// </summary>
    public interface IBaseStatRepository
    {
        /// <summary>
        /// Gets all the base stats.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BaseStatDTO> GetAll();
    }
}
