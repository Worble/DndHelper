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
    /// The skill repository.
    /// </summary>
    public class SkillRepository : ISkillRepository
    {
        #region data members and ctor

        private DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SkillRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region ISkillRepository inherited methods

        public IEnumerable<SkillDTO> GetAll()
        {
            return Skill.GetAll(context);
        }

        #endregion
    }
}
