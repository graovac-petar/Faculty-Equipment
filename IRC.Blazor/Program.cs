using IRC.Blazor.Services;
using IRC.Blazor.Services.Interfaces;
using IRC.DTOs.Filter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace IRC.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetConnectionString("ApiEndpoint")) });
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();
            builder.Services.AddScoped<IEquipmentAssignementService, EquipmentAssignementService>();
            builder.Services.AddScoped<FilterRequestDTO>();
            builder.Services.AddMudServices();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NewPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            await builder.Build().RunAsync();
        }
    }
}
