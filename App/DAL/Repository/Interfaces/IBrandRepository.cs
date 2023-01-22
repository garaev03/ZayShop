using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface IBrandRepository:ITEntityRepository<Brand>
    {
        void Delete(Brand brand);
    }
}
