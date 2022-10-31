using System.Threading.Tasks;
using Module3Practise4.Models;

namespace Module3Practise4.Services.Abstractions
{
    public interface IConfigService
    {
        Config Config { get; set; }
        Task SaveConfigAsync();
        Task LoadConfig();
    }
}
