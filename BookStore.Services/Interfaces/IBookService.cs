using BookStore.Core.Models;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken);

        Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken);

        Task<Guid> DeleteBookAsync(Guid bookId, CancellationToken cancellationToken);

        Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken);
    }
}
