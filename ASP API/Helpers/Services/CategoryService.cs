using ASP_API.Contexts;

namespace ASP_API.Helpers.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
    }
}
