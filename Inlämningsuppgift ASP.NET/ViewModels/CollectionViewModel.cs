using Inlämningsuppgift_ASP.NET.Models.DTO;

namespace Inlämningsuppgift_ASP.NET.ViewModels
{
    public class CollectionViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
