using Books.Models;

namespace Books.Data.Repositories
{
    public interface IStoriesRepository
    {
        public List<StoryModel> GetStories();
        public Task<StoryModel> GetStoriesByIdAsync(int storyId);
        public Task<int> StoreStoriesAsync(StoryModel story);
        public int UpdateStories(StoryModel story);
        public int DeleteStories(int storyId);
    }
}
