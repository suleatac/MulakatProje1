using App.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await productService.GetAllProductsAsync();
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode!, result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery] int id)
        {
            var result = await productService.GetProductByIdAsync(id);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode!, result.Message);
            }
            return Ok(result.Data);
        }

        public async Task<IActionResult> GetTopPriceProductsAsync([FromQuery] int count)
        {
            var result = await productService.GetTopPriceProductsAsync(count);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode!, result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
        {
            var result = await productService.CreateProductAsync(request);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode!, result.Message);
            }
            return Ok(result.Data);
        }





    }
}
