using BookStore.API.DTOs;
using BookStore.Core.Models;
using BookStore.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook([FromBody]BookDto bookDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Provided book information is not valid. Values that were incorrect: {string.Join(',', ModelState.Values).AsSpan()}");
                }

                var book = bookDto.Adapt<Book>();

                var result = await _bookService.AddBookAsync(book, cancellationToken);

                if (result.Id == Guid.Empty)
                {
                    return BadRequest("Object creation was unexpectedly interrupted. Try again!");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getBooks")]
        public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync(cancellationToken);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteBook")]
        public async Task<IActionResult> DeleteBook(Guid bookId, CancellationToken cancellationToken)
        {
            try
            {
                var deletedBookId = await _bookService.DeleteBookAsync(bookId, cancellationToken);

                if (deletedBookId == Guid.Empty)
                {
                    return BadRequest("Provided Id doesn't match any book. Please, check the correctness of the book ID.");
                }

                return Ok(deletedBookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateBook")]
        public async Task<IActionResult> UpdateBook(BookDto bookDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Provided book information is not valid. Values that were incorrected: {string.Join(',', ModelState.Values).AsSpan()}");
                }

                var book = bookDto.Adapt<Book>();

                var result = await _bookService.UpdateBookAsync(book, cancellationToken);

                if (result.Id == Guid.Empty)
                {
                    return BadRequest("Object update was unexpectedly interrupted. Try again!");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
