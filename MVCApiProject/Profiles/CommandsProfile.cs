using AutoMapper;
using MVCApiProject.Dtos;
using MVCApiProject.Models;

namespace MVCApiProject.Profiles
{
  public class CommandsProfile : Profile // inherits from the base class Profile.
  {
    public CommandsProfile()
    {
      // This is to map the source object and the destination objects
      CreateMap<Command, CommandReadDto>();

      // In this we are geting data from CommandCreateDto and we are sending it to domain class Command
      CreateMap<CommandCreateDto, Command>();

      CreateMap<CommandUpdateDto, CommandUpdateDto>();

      CreateMap<Command, CommandUpdateDto>();
    }
  }
}