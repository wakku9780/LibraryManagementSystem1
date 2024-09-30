using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class BookIssuesController : Controller
    {
        private readonly LibraryContext _context;

        public BookIssuesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: BookIssues/IssueBook
        public IActionResult IssueBook()
        {
            // You might need to pass Users and Books to the view for selection
            ViewData["Books"] = _context.Books.ToList();
            ViewData["Users"] = _context.Users.ToList(); // Assuming you have users
            return View();
        }

        // POST: BookIssues/IssueBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IssueBook([Bind("BookId,UserId")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                bookIssue.IssueDate = DateTime.Now; // Set current date as issue date
                _context.Add(bookIssue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to issued book list or home
            }

            return View(bookIssue);
        }



        // GET: BookIssues/ReturnBook/{id}
        public async Task<IActionResult> ReturnBook(int id)
        {
            var bookIssue = await _context.BookIssues
                .Include(bi => bi.Book)
                .Include(bi => bi.User)
                .FirstOrDefaultAsync(bi => bi.IssueId == id && bi.ReturnDate == null);

            if (bookIssue == null)
            {
                return NotFound();
            }

            return View(bookIssue);
        }

        // POST: BookIssues/ReturnBook/{id}
        [HttpPost, ActionName("ReturnBook")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var bookIssue = await _context.BookIssues.FindAsync(id);
            if (bookIssue != null)
            {
                bookIssue.ReturnDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index)); // Redirect to issued book list
        }




        // GET: BookIssues/Index
        public async Task<IActionResult> Index()
        {
            var bookIssues = await _context.BookIssues
                .Include(bi => bi.Book)
                .Include(bi => bi.User)
                .ToListAsync();

            return View(bookIssues);
        }




    }
}
