using Microsoft.AspNetCore.Mvc;
using Books.Models;
using Books.Data;
using Microsoft.EntityFrameworkCore;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext context { get; set; }
        public BooksController(AppDbContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            return View("Edit", new BookModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookModel book)
        {
            if(ModelState.IsValid)
            {
                if (book.BookId == 0)
                    context.Books.Add(book);
                else
                    context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index", "Books");
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.GenreName).ToList();
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(BookModel book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public IActionResult Index()
        {
            var books = context.Books
                .Include(b => b.Title)
                .Include(b => b.Author)
                .Include(b => b.PubYear)
                .Include(b => b.Genre)
                .Include(b => b.Rating)
                .Include(b => b.Description)
                .ToList();
            return View(books);
        }
    }
}