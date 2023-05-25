using Inlämningsuppgift_ASP.NET.Helpers;
using Inlämningsuppgift_ASP.NET.ViewModels;

namespace Inlämningsuppgift_ASP.NET.Services
{
    public class AccountService
    {

        private readonly ApiHelper _api;

        public AccountService(ApiHelper api)
        {
            _api = api;
        }

        public async Task<HttpResponseMessage> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                using var httpClient = new HttpClient();
                return await httpClient.PostAsJsonAsync(
                    _api.ApiAddressRoot($"/Authentication/Register?x-api-key={_api.ApiKey()}"), model);
            }
            catch { return null!; }
        }
    }
}
