using CodeTest.Domain.Areas.Products.Commands;
using CodeTest.Domain.Areas.Products.Entities;
using CodeTest.Domain.Areas.Products.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeTest.Domain.UnitTests.Areas.Products.Commands
{
    public class CreateProductCommandTests
    {
        [Fact]
        public async Task ShouldCreateProduct_WhenCalled()
        {
            // Arrange
            var productName = Guid.NewGuid().ToString();
            var productPrice = 2;

            var product = new Product { Id = 0, Name = productName, Price = productPrice };

            Product actualProduct = null;
            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(m => m.InsertAsync(
                    It.IsAny<Product>(),
                    It.IsAny<CancellationToken>()))
                .Callback<Product, CancellationToken>((requestProduct, _) => actualProduct = requestProduct)
                .Returns(Task.CompletedTask);

            var commandHandler = new CreateProductCommandHandler(repoMock.Object);
            var command = new CreateProductCommand { ProductName = productName, ProductPrice = productPrice };

            // Act
            await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            actualProduct.Should().BeEquivalentTo(product);
        }
    }
}