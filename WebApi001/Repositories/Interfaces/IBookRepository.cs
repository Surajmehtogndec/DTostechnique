using WebApi001.DTOs;
namespace WebApi001.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookRespondeDTOs>> GetAllBooksAsync( BookFilterDTO filter);
        Task<BookRespondeDTOs?> GetBookByIdAsync(int id);
        Task<BookRespondeDTOs> CreateBookAsync(CreateBookDTOs createBookDTO);
        Task<BookRespondeDTOs?> UpdateBookAsync(int id, UpdateBookDTOs updateBookDTO);
        Task<bool> DeleteBookAsync(int id);
    } 
}
                                                                                                        