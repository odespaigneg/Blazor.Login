using Blazor.Login.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        
        public HolidaysApiService(IHttpClientFactory clientFactory, HttpClient httpClient)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
        }

        // // Note: not need if you use typed httpclient with the specification startup
        //public HolidaysApiService(HttpClient client)
        //{
        //    client.BaseAddress = new Uri("https://date.nager.at/");
        //    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        //    Client = client;
        //}

        //public HttpClient Client { get; }

        public async Task<List<HolidayResponse>> GetHolidays(HolidayRequest holidaysRequest)
        {
            List<HolidayResponse> result;

            var url = $"api/v2/PublicHolidays/{holidaysRequest.Year}/{holidaysRequest.CountryCode}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

            //var client = _clientFactory.CreateClient("HolidaysApi");
            //var response = await client.SendAsync(request);

            // var response = await Client.GetAsync(url);

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayResponse>>(stringResponse,
                    new JsonSerializerOptions
                    { 
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            }
            else
            {
                result = Array.Empty<HolidayResponse>().ToList();
            }

            return result;
        }
    }
}
