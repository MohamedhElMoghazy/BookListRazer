using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazer.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;  
        }
        
        [BindProperty] // assume this book is the one to post and hanling 
        public Book book { get; set;  }
        public void OnGet()
        {


        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) // confirm there is output from the form and it is field
            {

                await _db.Book.AddAsync(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else // the filed is empty
            {
                return Page();

            }
        
        }
    }
}