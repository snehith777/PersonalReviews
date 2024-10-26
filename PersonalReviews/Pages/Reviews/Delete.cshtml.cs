// Pages/Reviews/Delete.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalReviews.Data;
using PersonalReviews.Models;

namespace PersonalReviews.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly ReviewContext _context;

        public DeleteModel(ReviewContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Review = await _context.Reviews.FindAsync(id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
