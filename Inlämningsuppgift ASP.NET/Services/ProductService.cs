using Inlämningsuppgift_ASP.NET.Helpers;
using Inlämningsuppgift_ASP.NET.Models.DTO;

namespace Inlämningsuppgift_ASP.NET.Services
{
    public class ProductService
    {

        private readonly ApiHelper _api;

        public ProductService(ApiHelper api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var http = new HttpClient();
            var products = await http.GetFromJsonAsync<IEnumerable<Product>>(_api.ApiAddressRoot($"/Product/all?x-api-key={_api.ApiKey()}"));

            return products!;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using var http = new HttpClient();
            var product = await http.GetFromJsonAsync<Product>(_api.ApiAddressRoot($"/Product/id?id={id}&x-api-key={_api.ApiKey()}"));

            return product!;
        }


        public async Task<IEnumerable<Product>> GetByTagAsync(string tag)
        {
            using var http = new HttpClient();
            var products = await http.GetFromJsonAsync<IEnumerable<Product>>(_api.ApiAddressRoot($"/Product/tag?tag={tag}&x-api-key={_api.ApiKey()}"));

            return products!;
        }

        public async Task<HttpResponseMessage> CreateAsync(Product product)
        {
            using var httpClient = new HttpClient();
            return await httpClient.PostAsJsonAsync(
                _api.ApiAddressRoot($"/Product/add?x-api-key={_api.ApiKey()}"), product);
        }
    }
}
