using Inlämningsuppgift_ASP.NET.Models.DTO;

namespace Inlämningsuppgift_ASP.NET.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Featured { get; set; } = new List<Product>();
        public IEnumerable<Product> Popular { get; set; } = new List<Product>();
        public IEnumerable<Product> New { get; set; } = new List<Product>();
    }
}
