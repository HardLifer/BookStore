namespace BookStore.API.DTOs
{
    public record class BookDto
    {
        public Guid Id { get; init; }

        public string Title { get; init; } = null!;

        public string Author { get; init; } = null!;

        public DateTime Published { get; init; }
    }
}