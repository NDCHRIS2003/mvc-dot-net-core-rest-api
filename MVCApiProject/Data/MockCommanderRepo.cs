using System.Collections.Generic;
using MVCApiProject.Models;

namespace MVCApiProject.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Boil an egg",Line="Boil water",Platform="Kettle & Pan"},
        new Command{Id=1, HowTo="Cut bread",Line="Get a Knife",Platform="Knife & chopping board"},
        new Command{Id=2,HowTo="Make a cup of tea",Line="Place teabag",Platform="Kettle & Cup"}
      };
      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle $ Pan" };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}