using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.UnitofWork
{
    public interface IUnitofWork
    {
        Task<int> SaveChangesAsync();
    }
}
