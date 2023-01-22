using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class ProductRepository : TEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db) { }

        public void Delete(Product product)
        {
            product.isDeleted = true;
        }
    }
}
