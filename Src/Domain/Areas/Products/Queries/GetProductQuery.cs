using CodeTest.Domain.Areas.Products.Entities;
using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.Domain.FluentErrors;
using FluentResults;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Queries
{
    public record GetProductQuery : IRequest<Result<Product>>
    {
        public int ProductId { get; init; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Result<Product>> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(query.ProductId, cancellationToken);

            if (product is null)
            {
                return Result.Fail(new NotFoundError("Product not found."));
            }

            return Result.Ok(product);
        }
    }
}