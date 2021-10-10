using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandsRepo
    {
        bool SaveChanges();

        // Platform Stuff
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExist(int platformId);
        bool ExternalPlatformExist(int externalPlatformId);

    
        //Commands Stuf
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);
    }
}