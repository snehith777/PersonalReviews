// Pages/Reviews/Create.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalReviews.Data;
using PersonalReviews.Models;

namespace PersonalReviews.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly ReviewContext _context;

        public CreateModel(ReviewContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Convert DateReviewed to UTC
            Review.DateReviewed = Review.DateReviewed.ToUniversalTime();

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
