using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class DiscountRepository : TEntityRepository<Discount>,IDiscountRepository
    {
        public DiscountRepository(AppDbContext db) : base(db){}

        public void Delete(Discount discount)
        {
            discount.isDeleted= true;
        }
    }
}
