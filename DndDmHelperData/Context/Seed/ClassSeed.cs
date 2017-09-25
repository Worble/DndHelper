using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context.Seed
{
    public static class ClassSeed
    {
        public static List<Class> Seed(DndDmHelperContext context)
        {
            List<Class> seed = new List<Class>();

            if(context.Classes.FirstOrDefault(e => e.Name == "Warrior") == null)
            {
                seed.Add(new Class() { Name = "Warrior" });
            }
            if (context.Classes.FirstOrDefault(e => e.Name == "Warlock") == null)
            {
                seed.Add(new Class() { Name = "Warlock" });
            }
            if (context.Classes.FirstOrDefault(e => e.Name == "Bard") == null)
            {
                seed.Add(new Class() { Name = "Bard" });
            }
            if (context.Classes.FirstOrDefault(e => e.Name == "Cleric") == null)
            {
                seed.Add(new Class() { Name = "Cleric" });
            }
            if (context.Classes.FirstOrDefault(e => e.Name == "Monk") == null)
            {
                seed.Add(new Class() { Name = "Monk" });
            }
            if (context.Classes.FirstOrDefault(e => e.Name == "Druid") == null)
            {
                seed.Add(new Class() { Name = "Druid" });
            }

            return seed;
        }
    }
}
