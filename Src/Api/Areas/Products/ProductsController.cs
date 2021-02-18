using CodeTest.Api.Areas.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Api.Areas.Products
{
    [ApiController]
    [Route("v1")]
    public class ProductsController : ControllerBase
    {
        [HttpPost("product")]
        public async Task<IActionResult> CreateProductAsync([FromForm] ProductRequestDto productRequest)
        {
            return Ok();
        }

        [HttpGet("product/{id:int}")]
        public async Task<ProductResponseDto> GetProductAsync([FromRoute] int id)
        {
            return new ProductResponseDto
            {
                Name = "A Name",
                Price = 1
            };
        }

        [HttpGet("products")]
        public async Task<IEnumerable<ProductResponseDto>> GetManyProductsAsync(CancellationToken cancellationToken)
        {
            return new List<ProductResponseDto>
            {
                new ProductResponseDto
                {
                    Name = "A Name",
                    Price = 1
                },
                new ProductResponseDto
                {
                    Name = "B Name",
                    Price = 1
                }
            };
        }

        [HttpPut("product/{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] int id)
        {
            return Ok();
        }

        [HttpDelete("product/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            return Ok();
        }
    }
}