using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using TomatoCalculator.Client.Services;

namespace TomatoCalculator.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.Services
                .AddBlazorise( options =>
                {
                    options.ChangeTextOnKeyPress = true;
                } )
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.Services.AddSingleton( new HttpClient
            {
                BaseAddress = new Uri( builder.HostEnvironment.BaseAddress )
            } );
            
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddScoped<TomatoCalculatorService>();
            builder.Services.AddScoped<RouteInformationService>();
            builder.Services.AddScoped<TomatoService>();
            builder.Services.AddScoped<ShippingService>();
            builder.Services.AddScoped<DriverInformationService>();

            await builder.Build().RunAsync();
        }
    }
}
