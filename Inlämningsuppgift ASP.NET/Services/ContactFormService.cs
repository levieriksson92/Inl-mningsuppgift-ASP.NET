using Inlämningsuppgift_ASP.NET.Helpers;
using Inlämningsuppgift_ASP.NET.Models.DTO;

namespace Inlämningsuppgift_ASP.NET.Services
{
    public class ContactFormService
    {
        private readonly ApiHelper _api;

        public ContactFormService(ApiHelper api)
        {
            _api = api;
        }

        public async Task<IEnumerable<ContactFormDto>> GetAllAsync()
        {
            using var http = new HttpClient();
            var comments = await http.GetFromJsonAsync<IEnumerable<ContactFormDto>>(_api.ApiAddressRoot($"/comments/all?x-api-key={_api.ApiKey()}"));

            return comments!;
        }

        public async Task<ContactFormDto> GetByIdAsync(int id)
        {
            using var http = new HttpClient();
            var comment = await http.GetFromJsonAsync<ContactFormDto>(_api.ApiAddressRoot($"/comments/id?id={id}&x-api-key={_api.ApiKey()}"));

            return comment!;
        }


        public async Task<HttpResponseMessage> CreateAsync(ContactFormDto comment)
        {
            using var httpClient = new HttpClient();
            return await httpClient.PostAsJsonAsync(
                _api.ApiAddressRoot($"/comments/add?x-api-key={_api.ApiKey()}"), comment);
        }
    }
}
