using CodeTest.Api.Areas.Products.Dtos;
using CodeTest.Domain.Areas.Products.Commands;
using CodeTest.Domain.Areas.Products.Queries;
using CodeTest.Domain.FluentErrors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Api.Areas.Products
{
    [ApiController]
    [Route("v1")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator) => _mediator = mediator;

        [HttpPost("product")]
        public async Task<IActionResult> CreateProductAsync([FromForm] InsertProductRequestDto productRequest, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand { ProductName = productRequest.Name, ProductPrice = productRequest.Price };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut("product/{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(
            [FromRoute] int id,
            [FromForm] UpdateProductRequestDto productRequest,
            CancellationToken cancellationToken)
        {
            var command = new UpdateProductCommand { ProductId = id, ProductName = productRequest.Name, ProductPrice = productRequest.Price };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.HasError<NotFoundError>())
            {
                var errors = result.Errors.OfType<NotFoundError>();
                return NotFound(new { Message = errors.Select(error => error.Message) });
            }

            return Ok();
        }

        [HttpDelete("product/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand { ProductId = id };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.HasError<NotFoundError>())
            {
                var errors = result.Errors.OfType<NotFoundError>();
                return NotFound(new { Message = errors.Select(error => error.Message) });
            }

            return Ok();
        }

        [HttpGet("product/{id:int}")]
        public async Task<ActionResult<GetProductResponseDto>> GetProductAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery { ProductId = id };
            var result = await _mediator.Send(query, cancellationToken);

            if (result.HasError<NotFoundError>())
            {
                var errors = result.Errors.OfType<NotFoundError>();
                return NotFound(new { Message = errors.Select(error => error.Message) });
            }

            var product = result.Value;
            return new GetProductResponseDto { Name = product.Name, Price = product.Price.ToString() };
        }


        [HttpGet("products")]
        public async Task<IEnumerable<GetAllProductsResponseDto>> GetManyProductsAsync(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();
            var results = await _mediator.Send(query, cancellationToken);

            return results.Value.Select(product => new GetAllProductsResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString()
            });
        }
    }
}