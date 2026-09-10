using WebApi001.Repositories.Interfaces;
using WebApi001.Data;
using WebApi001.DTOs;
using Mapster;
using WebApi001.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
namespace WebApi001.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarydbContext _context;

        public BookRepository(LibrarydbContext context)
        {
            _context = context;  
        }

        public async Task<List<BookRespondeDTOs>> GetAllBooksAsync(
         
         BookFilterDTO filter)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .AsQueryable();


            // searching

            if (!string.IsNullOrWhiteSpace(filter.search)){
                query = query.Where(b =>
                b.Title.Contains(filter.search));

                
            }
            // sorting

            var sortBy = filter.sortBy?.ToLower();
            var sortOrder = filter.sortOrder?.ToLower();

            if(sortBy == "year") {
                query = sortOrder == "Asc"
                        ? query.OrderBy(b => b.PublicationYear)
                        :query.OrderBy(b => b.PublicationYear);
            }

            //// Filtering

            //if (filter.CategoryId.HasValue)
            //{
            //    query = query.Where(
            //        b => b.CategoryId == filter.CategoryId.Value);
            //}

            //if (filter.AutherId.HasValue)
            //{
            //    query = query.Where(
            //        b => b.AuthorId == filter.AutherId.Value);
            //}

            //if (filter.PublisherId.HasValue)
            //{
            //    query = query.Where(
            //        b => b.PublisherId == filter.PublisherId.Value);
            //}

            //if (filter.PublicationYear.HasValue)
            //{
            //    query = query.Where(
            //        b => b.PublicationYear ==
            //             filter.PublicationYear.Value);
            //}

            var books = await query.ToListAsync();
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
