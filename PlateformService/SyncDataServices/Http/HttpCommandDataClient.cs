using Microsoft.Extensions.Configuration;
using PlateformService.Dtos;
using PlateformService.Models;
using System.Text;
using System.Text.Json;

namespace PlateformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlateformToCommand(PlateformReadDto plateformReadDto)
        {
            Console.WriteLine("SendPlateformToCommand");
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plateformReadDto),
                Encoding.UTF8,
                "application/json"
                );
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}/plateform", httpContent);
            Console.WriteLine($"post Async {_configuration["CommandService"]}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Okay from HttpCommandDataClient { _configuration["CommandService"]}");
            }
            else
            {
                Console.WriteLine("Not Okay from HttpCommandDataClient");
            }
        }
    }
}
