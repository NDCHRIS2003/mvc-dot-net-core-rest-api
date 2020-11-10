using Microsoft.EntityFrameworkCore;
using MVCApiProject.Models;

namespace MVCApiProject.Data
{
  public class MVCApiContext : DbContext
  {
    public MVCApiContext(DbContextOptions<MVCApiContext> opt) : base(opt)
    {

    }

    public DbSet<Command> Commands { get; set; }
  }
}