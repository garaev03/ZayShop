using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface IProductRepository : ITEntityRepository<Product>
    {
        void Delete(Product product);
    }
}
