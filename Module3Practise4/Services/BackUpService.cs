using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3Practise4.Services.Abstractions;

namespace Module3Practise4.Services
{
    public class BackUpService : IBackUpService
    {
        private readonly IFileService _fileService;
        private StreamWriter _streamWriter;
        private string _backUpFolderPath;

        public BackUpService(IFileService fileService, IConfigService configService)
        {
            _backUpFolderPath = configService.Config.BackUpFolderPath;

            if (!Directory.Exists(_backUpFolderPath))
            {
                Directory.CreateDirectory(_backUpFolderPath);
            }

            _fileService = fileService;
        }

        public async void CreateBackUpAsync(string text)
        {
            string nameFile = DateTime.UtcNow.ToString("yyyyMMdd_HH_mm_ss_fffff");
            nameFile = Path.Combine(_backUpFolderPath, $"{nameFile}.backup");
            _streamWriter = new StreamWriter(nameFile);
            await _fileService.WriteAsync(_streamWriter, text);
        }
    }
}
