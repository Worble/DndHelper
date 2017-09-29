using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.DTOs;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The skill repository interface.
    /// </summary>
    public interface ISkillRepository
    {
        /// <summary>
        /// Gets all the skills.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SkillDTO> GetAll();
    }
}
