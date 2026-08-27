using WebApi001.DTOs;

namespace WebApi001.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookRespondeDTOs>> GetAllBooksAsync();
        Task<BookRespondeDTOs?> GetBookByIdAsync(int id);
        Task<BookRespondeDTOs> CreateBookAsync(CreateBookDTOs createBookDTO);
        Task<BookRespondeDTOs?> UpdateBookAsync(int id, UpdateBookDTOs  updateBookDTO);
        Task<bool> DeleteBookAsync(int id);

    }
}
