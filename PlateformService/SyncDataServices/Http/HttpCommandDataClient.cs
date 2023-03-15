using PlateformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlateformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPlateformToCommand(PlateformReadDto plateformReadDto)
        {
            Console.WriteLine("SendPlateformToCommand");
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plateformReadDto),
                Encoding.UTF8,
                "application/json"
                );

            var response = await _httpClient.PostAsync("http://localhost:6000/api/c/plateform", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Okay from HttpCommandDataClient");
            }
            else
            {
                Console.WriteLine("Not Okay from HttpCommandDataClient");
            }
        }
    }
}
