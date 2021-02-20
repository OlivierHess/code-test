using CodeTest.Domain.Areas.Products.Entities;
using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.SqlDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.SqlDataAccess.Areas.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly CodeTestContext _dataContext;

        public ProductRepository(CodeTestContext dataContext) => _dataContext = dataContext;

        public async Task InsertAsync(Product product, CancellationToken cancellationToken)
        {
            await _dataContext.AddAsync(product, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
            => await _dataContext.SaveChangesAsync(cancellationToken);

        public async Task DeleteProduct(Product product, CancellationToken cancellationToken)
        {
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product> GetProduct(int productId, CancellationToken cancellationToken)
            => await _dataContext.Products.SingleOrDefaultAsync(prod => prod.Id == productId, cancellationToken);

        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken)
            => await _dataContext.Products.AsNoTracking().ToListAsync(cancellationToken);
    }
}