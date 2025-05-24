namespace CafeApp.Core.Models;

public abstract class EntityChanges
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // soft delete
    public DateTime? DeletedAt { get; set; }
}
