using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandsRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine(" ==> Getting Platforms from CommandsService");
            
            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine(" ==> Inbound POST# Commands Service");

            return Ok("Test Inbound Connection Works Fine.");
        }
    }
}