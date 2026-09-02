using WebApi001.Repositories.Interfaces;
using WebApi001.DTOs;
using WebApi001.Services.Interfaces;
namespace WebApi001.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PaginationResponseDTO<BookRespondeDTOs>> GetAllBooksAsync(PaginationRequestDTO pagination)
        {
            return await _bookRepository.GetAllBooksAsync(pagination);
        }

        public async Task<BookRespondeDTOs?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                throw new KeyNotFoundException(
                     $"Book with ID {id} not found.");
            }
            return book;
        }

        public async Task<BookRespondeDTOs> CreateBookAsync(CreateBookDTOs createBookDTO)
        {
            var book = await _bookRepository.CreateBookAsync(createBookDTO);
            if(book == null)
            {
                throw new InvalidOperationException("Failed to create book.");
            }
            return book;            
        }

        public async Task<BookRespondeDTOs?> UpdateBookAsync(int id, UpdateBookDTOs updateBookDTO)
        {
            var book = await _bookRepository.UpdateBookAsync(id, updateBookDTO);
            if(book == null)
            {
                throw new KeyNotFoundException(
                     $"Book with ID {id} not found.");
            }
            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var result = await _bookRepository.DeleteBookAsync(id);
            if (!result)
            {
                throw new KeyNotFoundException(
                    $"Book with ID {id} not found.");
            }
             
            return true;
        }
    }
}
