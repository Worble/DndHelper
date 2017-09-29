using DndDmWebApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels.NoteViewModels
{
    /// <summary>
    /// The note edit view model.
    /// </summary>
    public class NoteEditViewModel
    {
        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public NoteModel Note { get; set; }

        /// <summary>
        /// Gets or sets the note types.
        /// </summary>
        /// <value>
        /// The note types.
        /// </value>
        public IEnumerable<NoteTypeModel> NoteTypes { get; set; }
    }
}
