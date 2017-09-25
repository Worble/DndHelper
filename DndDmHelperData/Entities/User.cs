using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Context;
using System.Linq;
using DndDmHelperData.Repositories.Interfaces;

namespace DndDmHelperData.Entities
{
    /// <summary>
    /// Represents a user entity in the databases
    /// </summary>
    /// <seealso cref="DndDmHelperData.Entities.BaseEntity" />
    public class User : BaseEntity
    {
        #region Data members
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the games the user owns.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public ICollection<Game> Games { get; set; }
        #endregion

        #region data access

        /// <summary>
        /// Gets the specified user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static UserDTO GetDTO(DndDmHelperContext context, int id)
        {
            return context.Users
                .Select(e => UserDTO.GenerateDTOFromUser(e))
                .FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        internal static UserDTO Login(DndDmHelperContext context, string emailAddress, string password)
        {
            var user = context.Users.FirstOrDefault(e => e.EmailAddress == emailAddress);
            if(!(user == null) && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return UserDTO.GenerateDTOFromUser(user);
            }
            return null;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        internal static void Register(DndDmHelperContext context, string emailAddress, string password)
        {
            context.Users.Add(new User() { EmailAddress = emailAddress, Password = BCrypt.Net.BCrypt.HashPassword(password) });
        }

        /// <summary>
        /// Checks the email is unique.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <returns></returns>
        internal static bool CheckUniqueEmail(DndDmHelperContext context, string emailAddress)
        {
            return context.Users.FirstOrDefault(e => e.EmailAddress == emailAddress) == null ? true : false;
        }
        #endregion
    }
}
