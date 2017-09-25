using DndDmHelperData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.UnitOfWork.Interface
{
    /// <summary>
    /// The unit of work interface
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets the game repository.
        /// </summary>
        /// <value>
        /// The game repository.
        /// </value>
        IGameRepository GameRepository { get; }

        /// <summary>
        /// Gets the template character repository.
        /// </summary>
        /// <value>
        /// The template character repository.
        /// </value>
        ITemplateCharacterRepository TemplateCharacterRepository { get; }

        /// <summary>
        /// Gets the game character repository.
        /// </summary>
        /// <value>
        /// The game character repository.
        /// </value>
        IGameCharacterRepository GameCharacterRepository { get; }

        /// <summary>
        /// Gets the class repository.
        /// </summary>
        /// <value>
        /// The class repository.
        /// </value>
        IClassRepository ClassRepository { get; }

        /// <summary>
        /// Gets the race repository.
        /// </summary>
        /// <value>
        /// The race repository.
        /// </value>
        IRaceRepository RaceRepository { get; }

        /// <summary>
        /// Gets the base stat repository.
        /// </summary>
        /// <value>
        /// The base stat repository.
        /// </value>
        IBaseStatRepository BaseStatRepository { get; }

        /// <summary>
        /// Save all changes to the database context
        /// </summary>
        void Save();
    }
}
