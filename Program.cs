using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TaskManager.Services;
using TaskManager.Interfaces;


namespace TaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var menu = host.Services.GetRequiredService<Menu>();
            menu.ShowMenu();
            
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<Menu>();
        });
    }
}