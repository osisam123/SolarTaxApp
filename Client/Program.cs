using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SolarTaxApp.Client.ViewModels;

namespace SolarTaxApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<ICategoryViewModel, CategoryViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<IClassificationViewModel, ClassificationViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<IStateTaxViewModel, StateTaxViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<IStateViewModel, StateViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<ITaxViewModel, TaxViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<ITaxTreatementViewModel, TaxTreatementViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<IClassificationListViewModel, ClassificationListViewModel>("SolarTaxApp", Client => Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddSingleton<StateContainer>();
            await builder.Build().RunAsync();
        }
    }
}
