using System.IO;
using System.Threading.Tasks;

namespace Module3Practise4.Services.Abstractions
{
    public interface IFileService
    {
        Task WriteAsync(StreamWriter streamWriter, string text);
    }
}
