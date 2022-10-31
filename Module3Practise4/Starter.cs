using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3Practise4.Models;
using Module3Practise4.Services.Abstractions;

namespace Module3Practise4
{
    public class Starter
    {
        private StreamWriter _streamWriter;
        public Starter(ILogger logger, IBackUpService backUpService, IConfigService configService)
        {
            Logger = logger;
            BackUpService = backUpService;
            _streamWriter = new StreamWriter(Path.Combine(configService.Config.LogFolderPath, configService.Config.LogNameFile));
        }

        public ILogger Logger { get; }
        public IBackUpService BackUpService { get; }

        public async Task Run()
        {
            Logger.EventBackUp += BackUpService.CreateBackUpAsync;

            var task1 = Task.Run(async () => await LogGenerator(50, "Thread 1"));
            var task2 = Task.Run(async () => await LogGenerator(50, "Thread 2"));

            await Task.WhenAll(task1, task2);
            await _streamWriter.DisposeAsync();
        }

        public async Task LogGenerator(int countLogs, string message)
        {
            var rnd = new Random();

            for (var i = 0; i < countLogs; i++)
            {
                await Logger.Log((LogType)rnd.Next(3), _streamWriter, $"{message}-{i}");
            }
        }
    }
}
