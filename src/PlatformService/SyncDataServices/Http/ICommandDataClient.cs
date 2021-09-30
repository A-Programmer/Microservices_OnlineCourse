using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommands(PlatformReadDto platform);
    }
}