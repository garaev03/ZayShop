using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class BrandRepository : TEntityRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext db) : base(db) { }

        public void Delete(Brand brand)
        {
            brand.isDeleted = true;
        }
    }
}
