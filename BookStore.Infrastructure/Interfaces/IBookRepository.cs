using BookStore.Core.Models;

namespace BookStore.Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken);

        Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken);

        Task<Guid> DeleteBookAsync(Guid bookId, CancellationToken cancellationToken);

        Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken);
    }
}
