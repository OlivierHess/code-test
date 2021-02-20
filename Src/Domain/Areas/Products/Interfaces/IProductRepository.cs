using CodeTest.Domain.Areas.Products.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Interfaces
{
    public interface IProductRepository
    {
        Task InsertAsync(Product product, CancellationToken cancellationToken);

        Task UpdateAsync(Product product, CancellationToken cancellationToken);

        Task DeleteProduct(Product product, CancellationToken cancellationToken);

        Task<Product> GetProduct(int productId, CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken);
    }
}