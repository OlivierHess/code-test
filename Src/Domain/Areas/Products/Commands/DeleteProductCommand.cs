using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.Domain.FluentErrors;
using FluentResults;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Commands
{
    public record DeleteProductCommand : IRequest<Result>
    {
        public int ProductId { get; init; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(command.ProductId, cancellationToken);

            if (product is null)
            {
                return Result.Fail(new NotFoundError("Product not found."));
            }

            await _productRepository.DeleteProduct(product, cancellationToken);

            return Result.Ok();
        }
    }
}