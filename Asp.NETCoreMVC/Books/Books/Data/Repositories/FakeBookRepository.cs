using Books.Models;

namespace Books.Data
{
    public class FakeBookRepository : IBooksRepository
    {
        List<BookModel> books = new List<BookModel>();

        public BookModel GetBookModelById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookModel> GetBookModels()
        {
            throw new NotImplementedException();
        }

        public int StoreBookModel(BookModel book)
        {
            book.BookId = books.Count + 1;
            books.Add(book);
            return book.BookId;
        }
    }
}