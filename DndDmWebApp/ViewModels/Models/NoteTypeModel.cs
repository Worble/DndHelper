using System;
using DndDmHelperData.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DndDmWebApp.ViewModels.Models
{
    public class NoteTypeModel
    {
        #region data members
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Type")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the lasted edited.
        /// </summary>
        /// <value>
        /// The lasted edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        internal static NoteTypeModel GenerateNoteTypeModelFromDTO(NoteTypeDTO noteType)
        {
            return new NoteTypeModel()
            {
                ID = noteType.ID,
                Name = noteType.Name,
                LastEdited = noteType.LastEdited
            };
        }
        #endregion

        #region methods

        #endregion
    }
}