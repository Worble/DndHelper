using DndDmHelperData.Context;
using DndDmHelperData.Entities;
using DndDmHelperData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Repositories
{
    /// <summary>
    /// Represents the User Repository
    /// </summary>
    /// <seealso cref="DndDmHelperData.Repositories.Interfaces.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        #region data members and ctor

        DndDmHelperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(DndDmHelperContext context)
        {
            this.context = context;
        }

        #endregion

        #region IUserRepository inherited methods

        /// <summary>
        /// Gets the user entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public UserDTO GetDTO(int id)
        {
            return User.GetDTO(context, id);
        }

        /// <summary>
        /// Logins the with the given email address and password.
        /// </summary>
        /// <param name="emailAddressOrUsername">The email address or username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserDTO Login(string emailAddress, string password)
        {
            return User.Login(context, emailAddress, password);
        }

        /// <summary>
        /// Registers the a user with the specified details.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Register(string emailAddress, string password)
        {
            User.Register(context, emailAddress, password);
        }

        /// <summary>
        /// Checks the given email is unique. Returns true when unique; otherwise false.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>
        /// True when unique; otherwise false
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CheckUniqueEmail(string emailAddress)
        {
            return User.CheckUniqueEmail(context, emailAddress);
        }

        #endregion
    }
}
