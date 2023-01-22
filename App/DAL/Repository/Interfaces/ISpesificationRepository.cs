using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface ISpesificationRepository:ITEntityRepository<ProductSpesification>
    {
        void Delete(ProductSpesification spesification);
    }
}
