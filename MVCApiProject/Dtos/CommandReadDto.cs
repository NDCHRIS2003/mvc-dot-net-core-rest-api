namespace MVCApiProject.Dtos
{
  // The idea of creating this class is to avoid exposing our domain entities to client
  // and also to select only the object we want to display to our clients.
  public class CommandReadDto
  {


    public int Id { get; set; }


    public string HowTo { get; set; }

    public string Line { get; set; }

    //public string Platform { get; set; }
  }
}