using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Books.Models;
using Books.Data.Repositories;
using Books.Data;

namespace Books.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository crepository;
        private readonly IStoriesRepository srepository;
        private readonly AppDbContext context;
        private readonly UserManager<AppUserModel> userManager;
        public CommentsController(ICommentsRepository c, IStoriesRepository s, AppDbContext dbcontext, UserManager<AppUserModel> u)
        {
            crepository = c;
            srepository = s;
            context = dbcontext;
            userManager = u;
        }

        /*
        [HttpGet]
        [Authorize]
        public IActionResult AddComment(int id)
        {
            ViewBag.Action = "Add";
            var comment = crepository.GetCommentsByIdAsync(id).Result;
            return View(comment);
        }
        */

        [HttpGet]
        [Authorize]
        public IActionResult AddComment(int storyId)
        {
            var story = srepository.GetStoriesByIdAsync(storyId).Result;
            var comment = new CommentsModel { Story = story, StoryId = storyId };
            return View(comment);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CommentsModel model)
        {
            if(userManager != null)
            {
                model.User = userManager.GetUserAsync(User).Result;
            }

            await crepository.StoreCommentsAsync(model);
            return RedirectToAction("Index", "Stories");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await crepository.GetCommentsByIdAsync(commentId);
            return View(comment);
        }

        [HttpPost]
        public IActionResult DeleteComment(CommentsModel model)
        {
            crepository.DeleteComments(model.CommentId);
            return RedirectToAction("Index", "Stories");
        }
    }
}
