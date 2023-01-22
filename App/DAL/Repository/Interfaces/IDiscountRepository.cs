using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface IDiscountRepository:ITEntityRepository<Discount>
    {
        void Delete(Discount discount);
    }
}
