using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class StoriesRepository : IStoriesRepository
    {
        AppDbContext context;
        public StoriesRepository(AppDbContext c)
        {
            context = c;
        }

        public async Task<StoryModel> GetStoriesByIdAsync(int id)
        {
            var story = await context.Stories.FindAsync(id);
            return story;
        }

        public List<StoryModel> GetStories()
        {
            return context.Stories
                .Include(s => s.Comments)
                .Include(g => g.Genre)
                .ToList();
        }

        public async Task<int> StoreStoriesAsync(StoryModel model)
        {
            await context.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public int UpdateStories(StoryModel model)
        {
            context.Update(model);
            return context.SaveChanges();
        }

        /*
        public int DeleteStories(int storyId)
        {
            StoryModel story = GetStoriesByIdAsync(storyId).Result;
            context.Stories.Remove(story);
            return context.SaveChanges();
        }
        */

        public int DeleteStories(int storyId)
        {
            StoryModel story = context.Stories.Include(s => s.Comments).SingleOrDefault(s => s.StoryId == storyId);
            context.Comments.RemoveRange(story.Comments);
            context.Stories.Remove(story);
            return context.SaveChanges();
        }
    }
}
