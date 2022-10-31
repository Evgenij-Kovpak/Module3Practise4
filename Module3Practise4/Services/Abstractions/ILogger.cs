using System;
using System.IO;
using System.Threading.Tasks;
using Module3Practise4.Models;

namespace Module3Practise4.Services.Abstractions
{
    public interface ILogger
    {
        event Action<string> EventBackUp;

        Task Log(LogType logType, StreamWriter streamWriter, string message);
    }
}
