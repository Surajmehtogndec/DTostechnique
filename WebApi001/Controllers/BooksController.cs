using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi001.Data;
using WebApi001.DTOs;
using WebApi001.Model;
using WebApi001.Repositories.Interfaces;


namespace WebApi001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly LibrarydbContext context;
        
        public BooksController(LibrarydbContext context, IBookRepository bookRepository)
        {
            this.context = context;
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
           var result = await _bookRepository.GetAllBooksAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
           var result = await _bookRepository.GetBookByIdAsync(id);
            if (result == null)
            {
                return NotFound(new
                {
                    message = $"Book with ID {id} not found."
                });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTOs createBookDTO)
        {
          var result = await _bookRepository.CreateBookAsync(createBookDTO);
            return Ok(result);
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound(new
                {
                    message = $"Book with ID {id} not found."
                });
            }
            return Ok(new
            {
                message = $"Book with ID {id} deleted successfully."
            });
        }

            
        


    }
}
