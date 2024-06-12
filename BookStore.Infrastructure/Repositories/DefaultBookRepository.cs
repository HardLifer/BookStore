using BookStore.Core.Models;
using BookStore.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BookStore.Infrastructure.Repositories
{
    public class DefaultBookRepository : IBookRepository
    {
        private readonly ILogger<DefaultBookRepository> _logger;

        private readonly List<Book> _books;

        public DefaultBookRepository(ILogger<DefaultBookRepository> logger)
        {
            _logger = logger;
            _books = new List<Book>();
        }

        public Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken)
        {
            try
            {
                _books.Add(book);

                return Task.FromResult(book);
            }
            catch (Exception ex)
            {
                _logger.LogError("The problem occured in the Add method of default repository. Exception message = {message}", ex.Message);

                return Task.FromResult(new Book());
            }
        }

        public Task<Guid> DeleteBookAsync(Guid bookId, CancellationToken cancellationToken)
        {
            try
            {
                var book = _books.FirstOrDefault(ent => ent.Id == bookId);

                if (book == null)
                {
                    _logger.LogError("The book with provided id={bookId} doesn't exist in the database. Provide correct id to delete the book.", bookId);

                    return Task.FromResult(Guid.Empty);
                }

                _books.Remove(book);

                return Task.FromResult(book.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("The problem occured in the Delete method of default repository. Exception message = {message}", ex.Message);

                return Task.FromResult(Guid.Empty);
            }
        }

        public Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_books.AsEnumerable());
            }
            catch (Exception ex)
            {
                _logger.LogError("The problem occured in the Get method of default repository. Exception message = {message}", ex.Message);

                return Task.FromResult(Enumerable.Empty<Book>());
            }
        }

        public Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken)
        {
            try
            {
                var currentBook = _books.FirstOrDefault(ent => ent.Id == book.Id);

                if (currentBook == null)
                {
                    _logger.LogError("The book with provided id={bookId} doesn't exist in the database. Provide correct book object to update existing one.", book.Id);

                    return Task.FromResult(new Book());
                }

                currentBook.Id = book.Id;
                currentBook.Title = book.Title;
                currentBook.Author = book.Author;
                currentBook.Published = book.Published;

                _books.RemoveAll(ent => ent.Id == book.Id);
                _books.Add(currentBook);

                return Task.FromResult(currentBook);
            }
            catch (Exception ex)
            {
                _logger.LogError("The problem occured in the Update method of default repository. Exception message = {message}", ex.Message);

                return Task.FromResult(new Book());
            }
        }
    }
}
