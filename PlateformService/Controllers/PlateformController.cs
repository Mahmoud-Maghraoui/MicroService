using AutoMapper;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;
using Microsoft.AspNetCore.Mvc;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformController : ControllerBase
    {
        private readonly IPlateformRepo _repository;
        private readonly IMapper _mapper;

        public PlateformController(IPlateformRepo plateformRepo, IMapper mapper)
        {
            _repository = plateformRepo;
            _mapper = mapper;
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
        public ActionResult<PlateformReadDto> CreatePlatefrom(PlateformCreateDto plateformCreateDto)
        {
            Plateform plateform = _mapper.Map<Plateform>(plateformCreateDto);
            _repository.CreatePlateform(plateform);
            _repository.SaveChanges();
            PlateformReadDto plateformReadDto = _mapper.Map<PlateformReadDto>(plateform);
            return CreatedAtRoute(nameof(GetPlateformById), new { Id = plateformReadDto.Id }, plateformReadDto);
        }
    }
}
