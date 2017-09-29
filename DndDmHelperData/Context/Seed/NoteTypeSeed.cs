using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context.Seed
{
    public static class NoteTypeSeed
    {
        public static List<NoteType> Seed(DndDmHelperContext context)
        {
            List<NoteType> seed = new List<NoteType>();

            if(context.NoteTypes.FirstOrDefault(e => e.Name == "Encounter") == null)
            {
                seed.Add(new NoteType() { Name = "Encounter" });
            }
            if (context.NoteTypes.FirstOrDefault(e => e.Name == "Plot") == null)
            {
                seed.Add(new NoteType() { Name = "Plot" });
            }
            if (context.NoteTypes.FirstOrDefault(e => e.Name == "Item") == null)
            {
                seed.Add(new NoteType() { Name = "Item" });
            }

            return seed;
        }
    }
}
