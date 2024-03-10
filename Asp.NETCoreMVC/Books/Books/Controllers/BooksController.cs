using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books.Models;
using Books.Data;
using Books.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext context;
        private readonly IBooksRepository brepository;
        private readonly UserManager<AppUserModel> userManager;

        public BooksController(AppDbContext c, IBooksRepository b, UserManager<AppUserModel> u)
        {
            context = c;
            brepository = b;
            userManager = u;
        }

        public IActionResult Index()
        {
            var books = brepository.GetBooks();
            return View(books);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            return View("Edit", new BookModel());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            var book = brepository.GetBooksByIdAsync(id).Result;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookModel book)
        {
            if (book.BookId == 0)
                await brepository.StoreBooksAsync(book);
            else
                brepository.UpdateBooks(book);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int bookId)
        {
            var book = await brepository.GetBooksByIdAsync(bookId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(BookModel model)
        {
            brepository.DeleteBooks(model.BookId);
            return RedirectToAction("Index", "Books");
        }
    }
}
