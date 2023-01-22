using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class SpesificationRepository : TEntityRepository<ProductSpesification>, ISpesificationRepository
    {
        public SpesificationRepository(AppDbContext db) : base(db) { }

        public void Delete(ProductSpesification spesification)
        {
            spesification.isDeleted=true;
        }
    }
}
