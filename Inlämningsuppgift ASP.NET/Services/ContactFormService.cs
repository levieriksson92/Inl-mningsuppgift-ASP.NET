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
            var forms = await http.GetFromJsonAsync<IEnumerable<ContactFormDto>>(_api.ApiAddressRoot($"/ContactForm/all?x-api-key={_api.ApiKey()}"));

            return forms!;
        }



        public async Task<HttpResponseMessage> CreateAsync(ContactFormDto contactform)
        {
            using var httpClient = new HttpClient();
            return await httpClient.PostAsJsonAsync(
                _api.ApiAddressRoot($"/ContactForm/add?x-api-key={_api.ApiKey()}"), contactform);
        }
    }
}
