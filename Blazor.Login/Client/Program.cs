using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor.Login.Client.Services;

namespace Blazor.Login.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<CustomStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // Note: not need if you use typed httpclient with the specification
            //builder.Services.AddScoped<IHolidaysApiService, HolidaysApiService>();

            // IHttpClientFactory
            builder.Services.AddHttpClient();

            // Named HttpClient
            builder.Services.AddHttpClient("HolidaysApi", c =>
            {
                c.BaseAddress = new Uri("https://date.nager.at/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            });

            // Typed HttpClient
            //builder.Services.AddHttpClient<HolidaysApiService>();
            builder.Services.AddHttpClient<IHolidaysApiService, HolidaysApiService>(c =>
            {
                c.BaseAddress = new Uri("https://date.nager.at/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            });

            // Local HttpClient
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
