using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface ISizeRepository : ITEntityRepository<Size>
    {
        void Delete(Size size);
    }
}
