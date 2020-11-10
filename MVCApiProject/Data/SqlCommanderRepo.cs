using System;
using System.Collections.Generic;
using System.Linq;
using MVCApiProject.Models;

namespace MVCApiProject.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly MVCApiContext _context;

    public SqlCommanderRepo(MVCApiContext context)
    {
      _context = context;
    }

    public void CreateCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentException(nameof(cmd));
      }
      _context.Commands.Remove(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var list = _context.Commands.ToList();
      return list;
    }

    public Command GetCommandById(int id)
    {
      var listId = _context.Commands.FirstOrDefault(cm => cm.Id == id);
      return listId;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
      // we will do nothing here as it will taken care of by DbContext.
    }
  }
}