using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi001.Data;
using WebApi001.DTOs;


namespace WebApi001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibrarydbContext context;
        public BooksController(LibrarydbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();

            var result = books.Select(b => new BookRespondeDTOs
            {
                Isbn = b.Isbn,
                Title = b.Title,
                Author = b.Author.Name,
                Category = b.Category.Name,
                Publisher = b.Publisher != null ? b.Publisher.Name : null,
                PublicationYear = b.PublicationYear,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies
            });
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            var result = new BookRespondeDTOs
            {
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author.Name,
                Category = book.Category.Name,
                Publisher = book.Publisher != null ? book.Publisher.Name : null,
                PublicationYear = book.PublicationYear,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTOs createBookDTO)
        {
            var book = new Model.Book
            {
                Isbn = createBookDTO.Isbn,
                Title = createBookDTO.Title,
                AuthorId = createBookDTO.AuthorId,
                CategoryId = createBookDTO.CategoryId,
                PublisherId = createBookDTO.PublisherId,
                PublicationYear = createBookDTO.PublicationYear,
                TotalCopies = createBookDTO.TotalCopies,
                AvailableCopies = createBookDTO.AvailableCopies,
                CreatedAt = DateTime.UtcNow
            };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDTOs updateBookDTO)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null)
            {
                return NotFound(new 
                {
                 message = $"Book with ID {id} not found."
                });
            }

            book.Isbn = updateBookDTO.Isbn;
            book.Title = updateBookDTO.Title;
            book.AuthorId = updateBookDTO.AuthorId;
            book.CategoryId = updateBookDTO.CategoryId;
            book.PublisherId = updateBookDTO.PublisherId;
            book.PublicationYear = updateBookDTO.PublicationYear;
            book.TotalCopies = updateBookDTO.TotalCopies;
            book.AvailableCopies = updateBookDTO.AvailableCopies;
            await context.SaveChangesAsync();
            return Ok(new
            {
                message = $"Book with ID {id} updated successfully."
            });
        }


    }
}
