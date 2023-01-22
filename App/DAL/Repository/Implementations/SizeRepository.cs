using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class SizeRepository : TEntityRepository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext db) : base(db) { }

        public void Delete(Size size)
        {
            size.isDeleted = true;
        }
    }
}
