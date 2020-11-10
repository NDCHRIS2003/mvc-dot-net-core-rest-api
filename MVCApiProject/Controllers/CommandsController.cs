using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MVCApiProject.Data;
using MVCApiProject.Dtos;
using MVCApiProject.Models;

namespace MVCApiProject.Controllers
{
  //[Route("api/[controller]")] what this does is that route will be "api/the name of controller", in this case "api/commands". However, the route will change once the name of the controller class changes
  [Route("api/commands")]  // this will make the route name to remain constant even if the controller class changes
  [ApiController]  // this attribute indicates that it is an API controller
  public class CommandsController : ControllerBase // it is inheriting ControllerBase because we are not working with Views. if not it should inherit Controller
  {
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    //Get api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommads()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));


    }

    //Get api/commands/{id}
    [HttpGet("{id}", Name = "GetCommandById")]  // the name attribute anotation is needed for CreateCommand action method. when returning CreateRoute method, you will need to pass it as parameter
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItems = _repository.GetCommandById(id);
      if (commandItems != null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItems));
      }
      else
      {
        return NotFound();
      }
    }

    //POST api/commands
    [HttpPost]
    public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      var commanModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commanModel);
      _repository.SaveChanges();
      var commandReadDto = _mapper.Map<CommandReadDto>(commanModel);

      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto); // this was used to avoid passing back or geting the instance of our model that is created. Rather we should display our commandReadDTO
      //return Ok(commandReadDto);
    }

    // PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      _mapper.Map(commandUpdateDto, commandModelFromRepo);
      _repository.UpdateCommand(commandModelFromRepo);
      _repository.SaveChanges();

      return NoContent();  // this will return 204 no content
    }
    //PATCH api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);

      if (!TryValidateModel(commandToPatch))
      {
        return ValidationProblem(ModelState);
      }
      _mapper.Map(commandToPatch, commandModelFromRepo);
      _repository.UpdateCommand(commandModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }

    // DELETE api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      _repository.DeleteCommand(commandModelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

  }
}
