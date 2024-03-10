using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        AppDbContext context;
        public CommentsRepository(AppDbContext c)
        {
            context = c;
        }

        public async Task<CommentsModel> GetCommentsByIdAsync(int id)
        {
            var comment = await context.Comments.FindAsync(id);
            return comment;
        }

        public List<CommentsModel> GetComments()
        {
            return context.Comments.ToList();
        }

        public async Task<int> StoreCommentsAsync(CommentsModel model)
        {
            await context.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public int DeleteComments(int commentId)
        {
            CommentsModel comment = GetCommentsByIdAsync(commentId).Result;
            context.Comments.Remove(comment);
            return context.SaveChanges();
        }
    }
}
