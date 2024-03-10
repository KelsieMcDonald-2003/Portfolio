using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        AppDbContext context;
        public BooksRepository(AppDbContext c)
        {
            context = c;
        }

        public async Task<BookModel> GetBooksByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            return book;
        }

        public List<BookModel> GetBooks()
        {
            return context.Books
                .Include(g => g.Genre)
                .ToList<BookModel>();
        }

        public async Task<int> StoreBooksAsync(BookModel book)
        {
            await context.AddAsync(book);
            return await context.SaveChangesAsync();
        }

        public int UpdateBooks(BookModel book)
        {
            context.Update(book);
            return context.SaveChanges();
        }

        public int DeleteBooks(int bookId)
        {
            BookModel book = GetBooksByIdAsync(bookId).Result;
            context.Books.Remove(book);
            return context.SaveChanges();
        }
    }
}
