using CodeTest.Domain.Areas.Products.Entities;
using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.SqlDataAccess.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.SqlDataAccess.Areas.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly CodeTestContext _dataContext;

        public ProductRepository(CodeTestContext dataContext) => _dataContext = dataContext;

        public async Task<int> InsertAsync(Product product, CancellationToken cancellationToken)
        {
            await _dataContext.AddAsync(product, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}