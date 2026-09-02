using WebApi001.Repositories.Interfaces;
using WebApi001.Data;
using WebApi001.DTOs;
using Mapster;
using WebApi001.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace WebApi001.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarydbContext _context;

        public BookRepository(LibrarydbContext context)
        {
            _context = context;  
        }

        public async Task<PaginationResponseDTO<BookRespondeDTOs>> GetAllBooksAsync(PaginationRequestDTO pagination)
        {
            var totalRecords = await _context.Books.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pagination.PageSize);


            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
            var data = books.Adapt<List<BookRespondeDTOs>>();
            return new PaginationResponseDTO<BookRespondeDTOs>
            {
                Data = data,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                HasNextPage = pagination.PageNumber < totalPages,
                HasPreviousPage = pagination.PageNumber > 1
               
            };
        }

        public async Task<BookRespondeDTOs?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);
            return book?.Adapt<BookRespondeDTOs>();
        }


        public async Task<BookRespondeDTOs> CreateBookAsync(
         CreateBookDTOs createBookDTO)
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

            _context.Books.Add(book); 

            await _context.SaveChangesAsync();

            return book.Adapt<BookRespondeDTOs>();
        }

        public async Task<BookRespondeDTOs?> UpdateBookAsync(int id, UpdateBookDTOs updateBookDTO)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            { 
                return null;
            }
            updateBookDTO.Adapt(book);
            await _context.SaveChangesAsync();
            return book.Adapt<BookRespondeDTOs>();
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id)                                       ;
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

      

    }
}
