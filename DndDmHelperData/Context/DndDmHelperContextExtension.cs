using DndDmHelperData.Context.Seed;
using DndDmHelperData.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context
{
    public static class DndDmHelperContextExtension
    {
        public static bool AllMigrationsApplied(this DndDmHelperContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DndDmHelperContext context)
        {
            context.Classes.AddRange(ClassSeed.Seed(context));
            context.SaveChanges();

            context.Races.AddRange(RaceSeed.Seed(context));
            context.SaveChanges();

            context.BaseStats.AddRange(BaseStatSeed.Seed(context));
            context.SaveChanges();
        }
    }
}
