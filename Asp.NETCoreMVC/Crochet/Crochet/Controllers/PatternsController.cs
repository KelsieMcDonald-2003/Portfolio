using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Crochet.Models;
using Crochet.Data;
using Crochet.Data.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crochet.Controllers
{
    public class PatternsController : Controller
    {
        private readonly IPatternsRepository prepository;
        private readonly IHooksRepository hrepository;
        private readonly ILevelsRepository lrepository;
        private readonly AppDbContext context;
        private readonly UserManager<AppUserModel> userManager;

        public PatternsController(IPatternsRepository p, IHooksRepository h, ILevelsRepository l, AppDbContext c, UserManager<AppUserModel> u)
        {
            prepository = p;
            hrepository = h;
            lrepository = l;
            context = c;
            userManager = u;
        }

        public IActionResult Index()
        {
            var patterns = prepository.GetPatterns();
            return View(patterns);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Hooks = hrepository.GetAll().OrderBy(h => h.HookId).ToList();
            ViewBag.Levels = lrepository.GetAll().OrderBy(l => l.LevelId).ToList();
            return View("Edit", new PatternsModel());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Hooks = hrepository.GetAll().OrderBy(h => h.HookId).ToList();
            ViewBag.Levels = lrepository.GetAll().OrderBy(l => l.LevelId).ToList();
            var pattern = prepository.GetPatternsByIdAsync(id).Result;
            return View(pattern);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatternsModel model)
        {
            model.Date = DateTime.Now;
            model.Publisher = userManager.GetUserAsync(User).Result;

            if (model.PatternId == 0)
                await prepository.StorePatternsAsync(model);
            else
                prepository.UpdatePatterns(model);

            return RedirectToAction("Index", "Patterns");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int patternId)
        {
            var pattern = await prepository.GetPatternsByIdAsync(patternId);
            return View(pattern);
        }

        [HttpPost]
        public IActionResult Delete(PatternsModel model)
        {
            prepository.DeletePatterns(model.PatternId);
            return RedirectToAction("Index", "Patterns");
        }
    }
}