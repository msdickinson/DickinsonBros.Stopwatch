﻿using DickinsonBros.Stopwatch.Runner.Services;
using DickinsonBros.Stopwatch.Abstractions;
using DickinsonBros.Stopwatch.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DickinsonBros.Stopwatch.Runner
{
    class Program
    {
        IConfiguration _configuration;
        async static Task Main()
        {
            await new Program().DoMain();
        }
        async Task DoMain()
        {
            try
            {
                var services = InitializeDependencyInjection();
                ConfigureServices(services);

                using (var provider = services.BuildServiceProvider())
                {
                    var stopwatchService = provider.GetRequiredService<IStopwatchService>();
                    var hostApplicationLifetime = provider.GetService<IHostApplicationLifetime>();

                    Console.WriteLine("Start Timer And Wait 1 Seconds");
                    stopwatchService.Start();
                    await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                    stopwatchService.Stop();
                    Console.WriteLine($"ElapsedMilliseconds: {stopwatchService.ElapsedMilliseconds}");

                    Console.WriteLine("Start Continue 2 Seconds");
                    stopwatchService.Start();
                    await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
                    stopwatchService.Stop();
                    Console.WriteLine($"ElapsedMilliseconds: {stopwatchService.ElapsedMilliseconds}");

                    Console.WriteLine("Start Timer Reset");
                    stopwatchService.Reset();
                    Console.WriteLine($"ElapsedMilliseconds: {stopwatchService.ElapsedMilliseconds}");

                    Console.WriteLine("Start Timer And Wait 1 Seconds");
                    stopwatchService.Start();
                    await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                    stopwatchService.Stop();
                    Console.WriteLine($"ElapsedMilliseconds: {stopwatchService.ElapsedMilliseconds}");

                    hostApplicationLifetime.StopApplication();
                }
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("End...");
                Console.ReadKey();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging(config =>
            {
                config.AddConfiguration(_configuration.GetSection("Logging"));

                if (Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") == "DEBUG")
                {
                    config.AddConsole();
                }
            });

            services.AddSingleton<IHostApplicationLifetime, HostApplicationLifetime>();
            services.AddStopwatchService();
        }

        IServiceCollection InitializeDependencyInjection()
        {
            var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true);
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            return services;
        }
    }
}
