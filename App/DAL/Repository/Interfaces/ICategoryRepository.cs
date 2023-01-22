using Zay.Core.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface ICategoryRepository : ITEntityRepository<Category>
    {
        void Delete(Category category);
    }
}
