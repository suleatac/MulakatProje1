using App.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await productService.GetAllProductsAsync();

            return CreateActionResult(result);
            //if (result.Status==HttpStatusCode.NoContent)
            //{
            //    return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
            //}
            //return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await productService.GetProductByIdAsync(id);
            return CreateActionResult(result);
            //if (result.Status == HttpStatusCode.NoContent)
            //{
            //    return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
            //}
            //return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
        {
            var result = await productService.CreateProductAsync(request);
            return CreateActionResult(result);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductRequest request)
        {
            var result = await productService.UpdateProductAsync(id, request);
            return CreateActionResult(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await productService.DeleteProductAsync(id);
            return CreateActionResult(result);
        }

    }
}
