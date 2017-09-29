using DndDmHelperData.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.Models
{
    /// <summary>
    /// The note model.
    /// </summary>
    public class NoteModel
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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the note type identifier.
        /// </summary>
        /// <value>
        /// The note type identifier.
        /// </value>
        public int NoteTypeID { get; set; }

        /// <summary>
        /// Gets or sets the type of the note.
        /// </summary>
        /// <value>
        /// The type of the note.
        /// </value>
        [Display(Name = "Type")]
        public NoteTypeModel NoteType { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameID { get; set; }
        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        public GameModel Game { get; set; }

        /// <summary>
        /// Gets or sets the time last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        public DateTime LastEdited { get; set; }

        #endregion

        #region methods

        internal static NoteModel GenerateNoteModelFromDTO(NoteDTO note)
        {
            return new NoteModel()
            {
                ID = note.ID,
                Name = note.Name,
                Content = note.Content,
                NoteTypeID = note.NoteTypeID,
                NoteType = note.NoteType != null ? NoteTypeModel.GenerateNoteTypeModelFromDTO(note.NoteType) : null,
                GameID = note.GameID,
                Game = note.Game != null ? GameModel.GenerateGameModelFromDTO(note.Game) : null,
                LastEdited = note.LastEdited
            };
        }

        internal static NoteDTO GenerateNoteDTOFromModel(NoteModel note)
        {
            return new NoteDTO()
            {
                ID = note.ID,
                Name = note.Name,
                Content = note.Content,
                GameID = note.GameID,
                NoteTypeID = note.NoteTypeID
            };
        }

        #endregion
    }
}
