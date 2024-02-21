using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BooksRepository : IBooksRepository
    {
        AppDbContext context;
        public BooksRepository(AppDbContext c)
        {
            context = c;
        }

        public List<BookModel> GetBookModels()
        {
            return context.Books
                .Include(b => b.Title)
                .Include(b => b.PubYear)
                .Include(b => b.Author)
                .Include(b => b.GenreId)
                .Include(b => b.Description)
                .Include(b => b.Rating)
                .ToList();
        }

        public BookModel GetBookModelById(int id)
        {
            throw new NotImplementedException();
        }

        public int StoreBookModel(BookModel book)
        {
            context.Add(book);
            return context.SaveChanges();
        }
    }
}