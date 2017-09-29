using System;
using DndDmHelperData.DTOs;
using System.ComponentModel.DataAnnotations;
using DndDmWebApp.ViewModels.ClassViewModels;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The class model
    /// </summary>
    public class ClassModel
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
        [Required(ErrorMessage = "Class name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the edited time.
        /// </summary>
        /// <value>
        /// The edited time.
        /// </value>
        [Display(Name="Last Edited")]
        public DateTime LastEdited { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Generates the class model from the dto.
        /// </summary>
        /// <param name="class">The class.</param>
        /// <returns></returns>
        internal static ClassModel GenerateClassModelFromDTO(ClassDTO @class)
        {
            return new ClassModel()
            {
                ID = @class.ID,
                Name = @class.Name,
                LastEdited = @class.LastEdited
            };
        }

        internal static ClassDTO GenerateClassDTOFromModel(ClassModel model)
        {
            return new ClassDTO()
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        #endregion
    }
}