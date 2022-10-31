using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Module3Practise4.Models;
using Module3Practise4.Services.Abstractions;

namespace Module3Practise4
{
    public class Logger : ILogger
    {
        private readonly IConfigService _configService;
        private readonly StringBuilder _logs;
        private static int _counter = 0;
        private readonly IFileService _fileService;
        private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        public Logger(IFileService fileService, IConfigService configService)
        {
            _configService = configService;
            _fileService = fileService;
            _logs = new StringBuilder();
        }

        public event Action<string> EventBackUp;

        public async Task Log(LogType logType, StreamWriter streamWriter, string message)
        {
            await _semaphoreSlim.WaitAsync();
            _counter++;
            var log = $"{DateTime.UtcNow}: {logType}: {message}";
            Console.WriteLine(log);
            await _fileService.WriteAsync(streamWriter, log);
            _logs.AppendLine(log);

            if (_counter % _configService.Config.CountRecordsFlushBackUp == 0)
            {
                EventBackUp?.Invoke(_logs.AppendLine("============================================").ToString());
            }

            _semaphoreSlim.Release();
        }
    }
}
