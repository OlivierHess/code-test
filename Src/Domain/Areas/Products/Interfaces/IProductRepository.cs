using CodeTest.Domain.Areas.Products.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Domain.Areas.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<int> InsertAsync(Product product, CancellationToken cancellationToken);
    }
}