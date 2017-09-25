using DndDmHelperData.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Repositories.Interfaces;
using DndDmHelperData.Context;
using DndDmHelperData.Repositories;

namespace DndDmHelperData.UnitOfWork
{
    /// <summary>
    /// The unit of work
    /// </summary>
    /// <seealso cref="DndDmHelperData.UnitOfWork.Interface.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Data members and ctor

        DndDmHelperContext context;
        private IUserRepository userRepository;
        private IGameRepository gameRepository;
        private IRaceRepository raceRepository;
        private IClassRepository classRepository;
        private ITemplateCharacterRepository templateCharacterRepository;
        private IGameCharacterRepository gameCharacterRepository;
        private IBaseStatRepository baseStatRepository;

        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            context = new DndDmHelperContext();
        }

        #endregion

        #region IUnitOfWork inherited methods

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.context);
                }
                return this.userRepository;
            }
        }

        /// <summary>
        /// Gets the game repository.
        /// </summary>
        /// <value>
        /// The game repository.
        /// </value>
        public IGameRepository GameRepository
        {
            get
            {
                if(this.gameRepository == null)
                {
                    this.gameRepository = new GameRepository(this.context);
                }
                return this.gameRepository;
            }
        }

        /// <summary>
        /// Gets the race repository.
        /// </summary>
        /// <value>
        /// The race repository.
        /// </value>
        public IRaceRepository RaceRepository
        {
            get
            {
                if (this.raceRepository == null)
                {
                    this.raceRepository = new RaceRepository(this.context);
                }
                return this.raceRepository;
            }
        }

        /// <summary>
        /// Gets the template character repository.
        /// </summary>
        /// <value>
        /// The template character repository.
        /// </value>
        public ITemplateCharacterRepository TemplateCharacterRepository
        {
            get
            {
                if (this.templateCharacterRepository == null)
                {
                    this.templateCharacterRepository = new TemplateCharacterRepository(this.context);
                }
                return this.templateCharacterRepository;
            }
        }

        /// <summary>
        /// Gets the game character repository.
        /// </summary>
        /// <value>
        /// The game character repository.
        /// </value>
        public IGameCharacterRepository GameCharacterRepository
        {
            get
            {
                if (this.gameCharacterRepository == null)
                {
                    this.gameCharacterRepository = new GameCharacterRepository(this.context);
                }
                return this.gameCharacterRepository;
            }
        }

        /// <summary>
        /// Gets the class repository.
        /// </summary>
        /// <value>
        /// The class repository.
        /// </value>
        public IClassRepository ClassRepository
        {
            get
            {
                if (this.classRepository == null)
                {
                    this.classRepository = new ClassRepository(this.context);
                }
                return this.classRepository;
            }
        }

        public IBaseStatRepository BaseStatRepository
        {
            get
            {
                if(this.baseStatRepository == null)
                {
                    this.baseStatRepository = new BaseStatRepository(this.context);
                }
                return this.baseStatRepository;
            }
        }

        /// <summary>
        /// Save all changes to the database context
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
        #endregion

        #region IDisposable inherited methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
