using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using gamecenter.Client.Helpers;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Client.Repository.Interface;
using gamecenter.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using gamecenter.Client.Authentication;
using gamecenter.Client.Authentication.Interface;

namespace gamecenter.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IRepository, RepositoryInMemory>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddAuthorizationCore();
            services.AddScoped<JwtAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>(
                provider => provider.GetRequiredService<JwtAuthStateProvider>());
            services.AddScoped<ILoginService, JwtAuthStateProvider>(
                provider => provider.GetRequiredService<JwtAuthStateProvider>());
        }
    }
}
