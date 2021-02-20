using CodeTest.Domain.Areas.Products.Entities;
using CodeTest.Domain.Areas.Products.Interfaces;
using FluentResults;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Commands
{
    public record CreateProductCommand : IRequest<Result>
    {
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Result> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.ProductName,
                Price = command.ProductPrice
            };

            await _productRepository.InsertAsync(product, cancellationToken);

            return Result.Ok();
        }
    }
}