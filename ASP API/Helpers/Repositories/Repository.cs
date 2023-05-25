using ASP_API.Contexts;
using ASP_API.Models.DTO;
using ASP_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace ASP_API.Helpers.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                return entity!;

            }
            catch { }

            return null!;
        }

        public async Task<ProductHttpResponse> GetAsync(string articleNumber)
        {
            var item = await _context.Products.FindAsync(articleNumber);
            return item!;
        }

        public async Task<IEnumerable<ProductHttpResponse>> GetAllAsync()
        {
            var items = await _context.Products.ToListAsync();
            var products = new List<ProductHttpResponse>();

            foreach (var item in items)
                products.Add(item);

            return products;
        }

        public async Task<IEnumerable<ProductHttpResponse>> GetAllByTagAsync(string tag)
        {
            var items = await _context.Products.Where(x => x.Tag == tag).ToListAsync();
            var products = new List<ProductHttpResponse>();

            foreach (var item in items)
                products.Add(item);

            return products;
        }

        public async Task<ProductHttpResponse> CreateAsync(ProductEntity entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
