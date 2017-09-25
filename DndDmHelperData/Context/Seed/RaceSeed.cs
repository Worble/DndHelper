using System;
using System.Collections.Generic;
using System.Text;
using DndDmHelperData.Entities;
using System.Linq;

namespace DndDmHelperData.Context.Seed
{
    public static class RaceSeed
    {
        public static List<Race> Seed(DndDmHelperContext context)
        {
            List<Race> seed = new List<Race>();

            if (context.Races.FirstOrDefault(e => e.Name == "Human") == null)
            {
                seed.Add(new Race() { Name = "Human" });
            }
            if (context.Races.FirstOrDefault(e => e.Name == "Elf") == null)
            {
                seed.Add(new Race() { Name = "Elf" });
            }
            if (context.Races.FirstOrDefault(e => e.Name == "Halfling") == null)
            {
                seed.Add(new Race() { Name = "Halfling" });
            }
            if (context.Races.FirstOrDefault(e => e.Name == "Dwarf") == null)
            {
                seed.Add(new Race() { Name = "Dwarf" });
            }
            if (context.Races.FirstOrDefault(e => e.Name == "Gnome") == null)
            {
                seed.Add(new Race() { Name = "Gnome" });
            }
            if (context.Races.FirstOrDefault(e => e.Name == "Dragonborn") == null)
            {
                seed.Add(new Race() { Name = "Dragonborn" });
            }

            return seed;
        }
    }
}
