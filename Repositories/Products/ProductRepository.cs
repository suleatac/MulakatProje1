using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.Products
{
    public class ProductRepository(AppDbContext appDbContext) : GenericRepository<Product>(appDbContext), IProductRepository
    {
        public async Task<List<Product>> GetTopPriceProductsAsync(int categoryId)
        {
            return await Context.Products
                .OrderByDescending(p => p.Price)
                .Take(10).ToListAsync();
        }
    }
}
