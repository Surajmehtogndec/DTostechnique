using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using WebApi001.Data;
using WebApi001.Services.Interfaces;
using WebApi001.Repositories.Interfaces;
using WebApi001.DTOs;
using Mapster;
using WebApi001.DTOs.V2;

namespace WebApi001.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]                                                                                                                                                 
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;

        private readonly LibrarydbContext _context;

        public BooksController(LibrarydbContext context, IBookRepository bookRepository, IBookService bookService)
        {
            this._context = context;
            this._bookRepository = bookRepository;
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] BookFilterDTO filter)
        {
            var books = await _bookService.GetAllBooksAsync(filter);
            var response = books.Adapt<List<BookRespondeDTOsV2>>();
            return Ok(response);
        }
    }
}
