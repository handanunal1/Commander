using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));

        }
        //Get api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }


        //Post api/commands
        [HttpPost]

        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);


            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }



        //Put api/commands/{id}
        [HttpPut("{id}")]

        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = _repo.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, command); /*Updates the modal*/
            _repo.UpdateCommand(command);
            _repo.SaveChanges();

            return NoContent();
        }




        //Patch api/commands/{id}
        [HttpPatch("{id}")]

        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandPatch);

            if (!TryValidateModel(commandPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandPatch, commandModelFromRepo);
            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }


        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();

            }

            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }




    }
}

