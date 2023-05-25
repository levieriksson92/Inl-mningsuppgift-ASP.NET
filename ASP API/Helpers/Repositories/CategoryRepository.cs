using ASP_API.Contexts;
using ASP_API.Helpers.Repositories.Base;
using ASP_API.Models.Entity;

namespace ASP_API.Helpers.Repositories
{
    public class CategoryRepository : Repository<CategoryEntity>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
