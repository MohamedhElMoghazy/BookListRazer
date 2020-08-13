using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BookListRazer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazer.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public Book book { get; set; }
        public async Task OnGet(int id)
        {
            book = await _db.Book.FindAsync(id);

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(book.Id);
                BookFromDb.Name = book.Name;
                BookFromDb.ISBN = book.ISBN;
                BookFromDb.Author = book.Author;

                await _db.SaveChangesAsync(); // upadate field into database
                return RedirectToPage("Index");


            }
            return RedirectToPage();

        }
            
    }
}