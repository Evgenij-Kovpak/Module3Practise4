using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Module3Practise4.Services;
using Module3Practise4.Services.Abstractions;

namespace Module3Practise4
{
    public class Program
    {
        public static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IBackUpService, BackUpService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            await start.Run();
        }
    }
}
