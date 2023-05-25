using ASP_API.Models.Entity;

namespace ASP_API.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StarRating { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Tag { get; set; } = null!;



        public static implicit operator ProductDto(ProductEntity entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                StarRating = entity.StarRating,
                Category = entity.Category,
                Tag = entity.Tag!
            };
        }

        public static implicit operator ProductEntity(ProductDto product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                StarRating = product.StarRating,
                CategoryId = product.CategoryId,
                Tag = product.Tag
            };
        }
    }
}
