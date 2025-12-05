using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.Products
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int categoryId);
    }
}
