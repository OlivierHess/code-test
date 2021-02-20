using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.Domain.FluentErrors;
using FluentResults;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Commands
{
    public record UpdateProductCommand : IRequest<Result>
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal? ProductPrice { get; init; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Result> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(command.ProductId, cancellationToken);

            if (product is null)
            {
                return Result.Fail(new NotFoundError("Product not found."));
            }

            product.Name = !string.IsNullOrWhiteSpace(command.ProductName) ? command.ProductName : product.Name;
            product.Price = command.ProductPrice ?? product.Price;

            await _productRepository.UpdateAsync(product, cancellationToken);

            return Result.Ok();
        }
    }
}