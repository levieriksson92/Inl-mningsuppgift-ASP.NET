using ASP_API.Contexts;
using ASP_API.Helpers.Repositories;
using ASP_API.Models.DTO;
using ASP_API.Models.Entity;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ASP_API.Helpers.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly ProductRepository _productRepo;
        private readonly CategoryRepository _categoryRepo;

        public ProductService(DataContext context, ProductRepository productRepo, CategoryRepository categoryRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }


        public async Task<ProductEntity> CreateAsync(ProductDto product)
        {
            ProductEntity entity = product;
            return await _productRepo.AddAsync(entity);
        }


        public async Task<IEnumerable<ProductDto>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                var result = await _productRepo.GetAllAsync(expression);
                var products = new List<ProductDto>();
                foreach (var entity in result)
                {
                    ProductDto product = entity;
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            try
            {
                var result = await _productRepo.GetAllAsync();
                var products = new List<ProductDto>();
                foreach (var entity in result)
                {
                    ProductDto product = entity;
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<ProductDto> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _productRepo.GetAsync(expression);
            ProductDto product = entity;
            return product;
        }
    }
}
