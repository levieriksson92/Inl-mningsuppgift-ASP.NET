using ASP_API.Contexts;
using ASP_API.Helpers.Repositories.Base;
using ASP_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ASP_API.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Products.Include(p => p.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in {nameof(GetAllAsync)}: {ex.Message}");
                return Array.Empty<ProductEntity>();
            };
        }


        public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                return await _context.Products.Include(p => p.Category).Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in {nameof(GetAllAsync)}: {ex.Message}");
                return Array.Empty<ProductEntity>();
            }
        }


        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in {nameof(GetAsync)}: {ex.Message}");
                return null!;
            }
        }
    }
}
