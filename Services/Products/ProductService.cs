using App.Repositories;
using App.Repositories.Products;
using App.Repositories.UnitofWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository, IUnitofWork unitofWork) : IProductService
    {

        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductsAsync(count);


            var productAsDto=products.Select(p => new ProductDto(p.Id,p.Name,p.Price,p.Stock)).ToList();

            return new ServiceResult<List<ProductDto>>() {
                Data = productAsDto
            };
        }


        public async Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            var productAsDto = new ProductDto(product!.Id,product.Name,product.Price,product.Stock);



            if (product is null)
            {
                ServiceResult<ProductDto?>.Fail("Product not fount", System.Net.HttpStatusCode.NotFound);
            }
            return ServiceResult<ProductDto?>.Success(productAsDto!);

        }

        public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var newProduct = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };
            await productRepository.AddAsync(newProduct);
            await unitofWork.SaveChangesAsync();
            var response = new CreateProductResponse(newProduct.Id);
            return ServiceResult<CreateProductResponse>.Success(response);
        }

        public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return ServiceResult.Fail("Product not found", System.Net.HttpStatusCode.NotFound);
            }
            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;
            productRepository.Update(product);
            await unitofWork.SaveChangesAsync();
            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteProductAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return ServiceResult.Fail("Product not found", System.Net.HttpStatusCode.NotFound);
            }
            productRepository.Delete(product);
            await unitofWork.SaveChangesAsync();
            return ServiceResult.Success();
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAll().ToListAsync();
            var productAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
            return ServiceResult<List<ProductDto>>.Success(productAsDto);
        }
    }
}
