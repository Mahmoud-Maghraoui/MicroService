using AutoMapper;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;
using Microsoft.AspNetCore.Mvc;
using PlateformService.SyncDataServices.Http;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformController : ControllerBase
    {
        private readonly IPlateformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlateformController(
            IPlateformRepo plateformRepo,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _repository = plateformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet("{id}", Name = "GetPlateformById")]
        public PlateformReadDto GetPlateformById(int id)
        {
            return _mapper.Map<PlateformReadDto>(_repository.GetPlateformById(id));
        }

        [HttpGet(Name = "GetPlateforms")]
        public IEnumerable<PlateformReadDto> GetPlateforms()
        {
            return _mapper.Map<IEnumerable<PlateformReadDto>>(_repository.GetPlatforms());
        }

        [HttpPost]
        public async Task<ActionResult<PlateformReadDto>> CreatePlatefrom(PlateformCreateDto plateformCreateDto)
        {
            Plateform plateform = _mapper.Map<Plateform>(plateformCreateDto);
            _repository.CreatePlateform(plateform);
            _repository.SaveChanges();
            PlateformReadDto plateformReadDto = _mapper.Map<PlateformReadDto>(plateform);

            try
            {
                Console.WriteLine("CreatePlatefrom");

                await _commandDataClient.SendPlateformToCommand(plateformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("From plateformController: ", ex);
            }


            return CreatedAtRoute(nameof(GetPlateformById), new { Id = plateformReadDto.Id }, plateformReadDto);
        }
    }
}
