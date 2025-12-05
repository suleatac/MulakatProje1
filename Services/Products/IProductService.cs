using App.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
        Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id);
        Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);
        Task<ServiceResult> DeleteProductAsync(int id);
        Task<ServiceResult<List<ProductDto>>> GetAllProductsAsync();
    }
}
