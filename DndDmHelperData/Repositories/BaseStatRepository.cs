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
    /// The base stat repository.
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IBaseStatRepository" />
    public class BaseStatRepository : IBaseStatRepository
    {
        #region data members and ctor
        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseStatRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region IBaseStatRepository inherited methods

        public IEnumerable<BaseStatDTO> GetAll()
        {
            return BaseStat.GetAll(context);
        }

        #endregion
    }
}
