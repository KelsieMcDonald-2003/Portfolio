using Books.Models;

namespace Books.Data.Repositories
{
    public interface ICommentsRepository
    {
        public List<CommentsModel> GetComments();
        public Task<CommentsModel> GetCommentsByIdAsync(int id);
        public Task<int> StoreCommentsAsync(CommentsModel comment);
        public int DeleteComments(int storyId);
    }
}
