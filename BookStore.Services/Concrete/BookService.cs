using BookStore.Core.Models;
using BookStore.Infrastructure.Interfaces;
using BookStore.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookStore.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookRepository _bookRepository;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.AddBookAsync(book, cancellationToken);

            if (result.Id == Guid.Empty)
            {
                _logger.LogInformation("Repository returned empty object. Potential problem with Add method.");
            }

            return result;
        }

        public async Task<Guid> DeleteBookAsync(Guid bookId, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.DeleteBookAsync(bookId, cancellationToken);

            if (result == Guid.Empty)
            {
                _logger.LogInformation("Provided id isn't correct and entity with provided ID doesn't exist.");
            }

            return result;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync(cancellationToken);

            return books;
        }

        public async Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.UpdateBookAsync(book, cancellationToken);

            if (result.Id == Guid.Empty)
            {
                _logger.LogInformation("Repository returned empty object. Potential problem with Update method.");
            }

            return result;
        }
    }
}
