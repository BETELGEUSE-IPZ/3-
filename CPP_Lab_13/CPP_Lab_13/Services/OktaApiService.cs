
using Lab11.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Lab11.Services
{
    public class OktaApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public OktaApiService(string apiToken, IConfiguration configuration)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", apiToken);
            _configuration = configuration;
        }

        public async Task<AppUser> GetUserAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"{_configuration["Okta:Domain"]}/api/v1/users/{userId}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var oktaUser = JsonConvert.DeserializeObject<OktaUser>(json);

            return new AppUser()
            {
                Nickname = oktaUser.Profile.Nickname,
                FirstName = oktaUser.Profile.FirstName,
                LastName = oktaUser.Profile.LastName,
                MiddleName = oktaUser.Profile.MiddleName,
                Email = oktaUser.Profile.Email,
                PhoneNumber = oktaUser.Profile.PhoneNumber,
            };
        }
    }
}
