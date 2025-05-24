namespace CafeApp.Core.Models;

public class Review
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public int Grade { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
