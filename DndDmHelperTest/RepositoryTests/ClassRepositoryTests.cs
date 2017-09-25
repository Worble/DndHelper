using DndDmHelperData.Context;
using DndDmHelperData.DTOs;
using DndDmHelperData.Entities;
using DndDmHelperData.Repositories;
using DndDmHelperData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DndDmHelperTest
{
    public class ClassRepositoryTests
    {
        [Fact]
        public void GetAll_ReturnsZero_WhenThereAreNoClassesInTheDatabase()
        {
            using (var context = Helper.GetContext())
            {
                ClassRepository repository = new ClassRepository(context);
                var actual = repository.GetAll().Count();
                Assert.Equal(0, actual);
            }            
        }

        [Fact]
        public void GetAll_ReturnsOne_WhenThereIsOneClassInTheDatabase()
        {
            using (var context = Helper.GetContext())
            {
                context.Classes.Add(new Class() { Name = "Test" });
                context.SaveChanges();
                IClassRepository repository = new ClassRepository(context);
                var actual = repository.GetAll().Count();
                Assert.Equal(1, actual);
            }
        }

        [Fact]
        public void Add_IncreasesDatabaseCountByOneToOne_WhenThereAreNoOtherEntriesInTheDatabase()
        {
            using (var context = Helper.GetContext())
            {
                IClassRepository repository = new ClassRepository(context);
                repository.Add(new ClassDTO() { Name = "Test" });
                context.SaveChanges();
                var actual = context.Classes.Count();
                Assert.Equal(1, actual);
            }
        }
    }
}
