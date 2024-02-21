using Books.Models;

namespace Books.Data
{
    public interface IBooksRepository
    {
        public List<BookModel> GetBookModels();
        public BookModel GetBookModelById(int id);
        public int StoreBookModel(BookModel book);
    }
}