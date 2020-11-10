using System.ComponentModel.DataAnnotations;

namespace MVCApiProject.Dtos
{
  // The idea of creating this class is to avoid exposing our domain entities to client
  // and also to select only the object we want to display to our clients.
  // in create DTO we have to include all the objects that are required in our model class. 
  // we do not have to include ID as it is autho generated in the database
  public class CommandCreateDto
  {
    [Required]
    [MaxLength(250)]
    public string HowTo { get; set; }

    [Required]
    public string Line { get; set; }

    [Required]
    public string Platform { get; set; }
  }
}