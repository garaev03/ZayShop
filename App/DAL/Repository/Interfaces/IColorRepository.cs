using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface IColorRepository:ITEntityRepository<Color>
    {
        void Delete(Color color);
    }
}
