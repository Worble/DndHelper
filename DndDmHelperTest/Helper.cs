using DndDmHelperData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndDmHelperTest
{
    public static class Helper
    {
        public static DndDmHelperContext GetContext()
        {
            var options = new DbContextOptionsBuilder<DndDmHelperContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new DndDmHelperContext(options);
            return context;
        }
    }
}
