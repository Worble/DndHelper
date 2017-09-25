using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// The user repository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user entity with the specified identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        UserDTO GetDTO(int ID);

        /// <summary>
        /// Checks the given email is unique. Returns true when unique; otherwise false.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>True when unique; otherwise false</returns>
        bool CheckUniqueEmail(string emailAddress);

        /// <summary>
        /// Registers the a user with the specified details.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        void Register(string emailAddress, string password);

        /// <summary>
        /// Logins the with the given email address and password.
        /// </summary>
        /// <param name="emailAddress">The email address or username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserDTO Login(string emailAddress, string password);
    }
}
