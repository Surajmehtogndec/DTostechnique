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

        public async Task<List<BookRespondeDTOs>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();
            return books.Adapt<List<BookRespondeDTOs>>();
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

        public async Task<BookRespondeDTOs?> UpdateBookAsync(int id, CreateBookDTOs updateBookDTO)
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
