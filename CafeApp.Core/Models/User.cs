using System.ComponentModel.DataAnnotations.Schema;

namespace CafeApp.Core.Models;

[Table("Users")]
public abstract class User : EntityChanges
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{LastName} {FirstName}";

    public DateTime BirthDate { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }
}
