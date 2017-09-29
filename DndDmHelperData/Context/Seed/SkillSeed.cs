using DndDmHelperData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context.Seed
{
    public abstract class SkillSeed
    {
        public static List<Skill> Seed(DndDmHelperContext context)
        {
            List<Skill> seed = new List<Skill>();

            if(context.Skills.FirstOrDefault(e => e.Name == "Acrobatics") == null)
            {
                seed.Add(new Skill() { Name = "Acrobatics", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Animal Handling") == null)
            {
                seed.Add(new Skill() { Name = "Animal Handling", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Arcana") == null)
            {
                seed.Add(new Skill() { Name = "Arcana", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Athletics") == null)
            {
                seed.Add(new Skill() { Name = "Athletics", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Deception") == null)
            {
                seed.Add(new Skill() { Name = "Deception", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "History") == null)
            {
                seed.Add(new Skill() { Name = "History", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Insight") == null)
            {
                seed.Add(new Skill() { Name = "Insight", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Intimidation") == null)
            {
                seed.Add(new Skill() { Name = "Intimidation", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Investigation") == null)
            {
                seed.Add(new Skill() { Name = "Investigation", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Medicine") == null)
            {
                seed.Add(new Skill() { Name = "Medicine", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Nature") == null)
            {
                seed.Add(new Skill() { Name = "Nature", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Perception") == null)
            {
                seed.Add(new Skill() { Name = "Perception", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Performance") == null)
            {
                seed.Add(new Skill() { Name = "Performance", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Persuasion") == null)
            {
                seed.Add(new Skill() { Name = "Persuasion", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Religion") == null)
            {
                seed.Add(new Skill() { Name = "Religion", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Religion") == null)
            {
                seed.Add(new Skill() { Name = "Religion", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Sleight of Hand") == null)
            {
                seed.Add(new Skill() { Name = "Sleight of Hand", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Stealth") == null)
            {
                seed.Add(new Skill() { Name = "Stealth", Default = true });
            }
            if (context.Skills.FirstOrDefault(e => e.Name == "Survival") == null)
            {
                seed.Add(new Skill() { Name = "Survival", Default = true });
            }

            return seed;
        }
    }
}
