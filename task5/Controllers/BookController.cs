using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Context;
using task5.Models;

namespace task5.Controllers
{
    public class BookController : Controller
    {
        LibraryDbContext libraryDbContext = new LibraryDbContext();
        public IActionResult Read()
        {
            var query = libraryDbContext.Book.Include(book => book.Author).ToList();
            return View(query);
        }



        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var author = libraryDbContext.Author.FirstOrDefault(author => author.Name.ToLower() == book.Author.Name.ToLower());
            if (author != null)
            {
                if (author.Book == null)
                {
                    author.Book = new List<Book>();
                }
                author.Book.Add(book);
            }
            else
            {
                libraryDbContext.Book.Add(book);
            }
            libraryDbContext.SaveChanges();
            return RedirectToAction("Read");

        }




        public IActionResult Edit(int BookId)
        {
            var book = libraryDbContext.Book.Include(b => b.Author).FirstOrDefault(b => b.BookId == BookId);
            return View(book);
        }



        [HttpPost]
        public IActionResult Edit(Book book)
        {

            libraryDbContext.Book.Update(book);
            libraryDbContext.SaveChanges();
            return RedirectToAction("Read");

        }
        // i need to make a list of authors



        public IActionResult Delete(int BookId)
        {
            var delete = libraryDbContext.Book.FirstOrDefault(d => d.BookId == BookId);
            libraryDbContext.Book.Remove(delete);
            libraryDbContext.SaveChanges();
            return RedirectToAction("Read");
        }

    }
}
