using PlateformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlateformToCommand(PlateformReadDto plateformReadDto);
    }
}
