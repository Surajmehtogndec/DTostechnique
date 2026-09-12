using Asp.Versioning;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi001.Data;
using WebApi001.DTOs;
using WebApi001.Model;
using WebApi001.Repositories.Interfaces;
using WebApi001.Services.Interfaces;


namespace WebApi001.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/[controller]")] 
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository; 
        private readonly IBookService _bookService;
        private readonly LibrarydbContext context;
        
        public BooksController(LibrarydbContext context, IBookRepository bookRepository, IBookService bookService)
        {
            this.context = context;
            this._bookRepository = bookRepository;
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks( [FromQuery] BookFilterDTO filter)
        {
           var result = await _bookService.GetAllBooksAsync(filter);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
           var result = await _bookService.GetBookByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTOs createBookDTO)
        {
          var result = await _bookService.CreateBookAsync(createBookDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDTOs updateBookDTO)
        {
            var book = await _bookService.UpdateBookAsync(id, updateBookDTO);


            return Ok(book);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
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
