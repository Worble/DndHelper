using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context.Seed
{
    public static class BaseStatSeed
    {
        public static List<BaseStat> Seed(DndDmHelperContext context)
        {
            List<BaseStat> seed = new List<BaseStat>();

            if (context.BaseStats.FirstOrDefault(e => e.Name == "Strength") == null)
            {
                seed.Add(new BaseStat() { Name = "Strength", Default = true });
            }
            if (context.BaseStats.FirstOrDefault(e => e.Name == "Constitution") == null)
            {
                seed.Add(new BaseStat() { Name = "Constitution", Default = true });
            }
            if (context.BaseStats.FirstOrDefault(e => e.Name == "Dexterity") == null)
            {
                seed.Add(new BaseStat() { Name = "Dexterity", Default = true });
            }
            if (context.BaseStats.FirstOrDefault(e => e.Name == "Charisma") == null)
            {
                seed.Add(new BaseStat() { Name = "Charisma", Default = true });
            }
            if (context.BaseStats.FirstOrDefault(e => e.Name == "Intelligence") == null)
            {
                seed.Add(new BaseStat() { Name = "Intelligence", Default = true });
            }
            if (context.BaseStats.FirstOrDefault(e => e.Name == "Wisdom") == null)
            {
                seed.Add(new BaseStat() { Name = "Wisdom", Default = true });
            }

            return seed;
        }
    }
}
