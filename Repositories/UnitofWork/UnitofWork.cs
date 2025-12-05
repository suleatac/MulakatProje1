using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.UnitofWork
{
    public class UnitofWork(AppDbContext appDbContext) : IUnitofWork
    {
        public Task<int> SaveChangesAsync()
        {
            return appDbContext.SaveChangesAsync();
        }
    }
}
