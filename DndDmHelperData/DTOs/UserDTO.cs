using DndDmHelperData.Entities;
using System;

namespace DndDmHelperData.Repositories.Interfaces
{
    /// <summary>
    /// Represents the user data transfer object.
    /// </summary>
    public class UserDTO
    {
        #region Data members
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the userDTO from user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static UserDTO GenerateDTOFromUser(User user)
        {
            return new UserDTO()
            {
                ID = user.ID,
                EmailAddress = user.EmailAddress,
                LastEdited = user.EditedDate ?? user.CreatedDate
            };
        }

        #endregion
    }
}