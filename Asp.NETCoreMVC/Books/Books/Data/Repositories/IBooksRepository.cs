using Books.Models;

namespace Books.Data.Repositories
{
    public interface IBooksRepository
    {
        public List<BookModel> GetBooks();
        public Task<BookModel> GetBooksByIdAsync(int id);
        public Task<int> StoreBooksAsync(BookModel book);
        public int UpdateBooks(BookModel book);
        public int DeleteBooks(int bookId);
    }
}
