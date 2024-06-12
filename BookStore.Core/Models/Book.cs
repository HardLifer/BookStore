namespace BookStore.Core.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime Published { get; set; }
}