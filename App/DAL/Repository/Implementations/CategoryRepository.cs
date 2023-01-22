using Zay.Core.Repository.Implementations;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class CategoryRepository : TEntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db) { }

        public void Delete(Category category)
        {
            category.isDeleted = true;
        }
    }
}
