using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Books.Models;
using Books.Data;
using Books.Data.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IStoriesRepository srepository;
        private readonly ICommentsRepository crepository;
        private readonly AppDbContext context;
        private readonly UserManager<AppUserModel> userManager;

        public StoriesController(IStoriesRepository s, ICommentsRepository com, AppDbContext con, UserManager<AppUserModel> u)
        {
            srepository = s;
            crepository = com;
            context = con;
            userManager = u;
        }
        public IActionResult Index()
        {
            var stories = srepository.GetStories(); //.Include(s => s.Comments);
            return View(stories);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreId).ToList();
            return View("Edit", new StoryModel());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreId).ToList();
            var story = srepository.GetStoriesByIdAsync(id).Result;
            return View(story);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StoryModel model)
        {
            model.Date = DateTime.Now;
            model.User = userManager.GetUserAsync(User).Result;

            if (model.StoryId == 0)
                await srepository.StoreStoriesAsync(model);
            else
                srepository.UpdateStories(model);
            return RedirectToAction("Index", "Stories");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int storyId)
        {
            var story = await srepository.GetStoriesByIdAsync(storyId);
            return View(story);
        }

        [HttpPost]
        public IActionResult Delete(StoryModel smodel)
        {
            srepository.DeleteStories(smodel.StoryId);
            return RedirectToAction("Index", "Stories");
        }
    }
}
