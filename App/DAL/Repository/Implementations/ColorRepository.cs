using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class ColorRepository : TEntityRepository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext db) : base(db) { }

        public void Delete(Color color)
        {
            color.isDeleted = true;
        }
    }
}
