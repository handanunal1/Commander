using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        //Get api//commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();
            return Ok (commandItems);

        }
        //Get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }
    }
}
 
