// Pages/Reviews/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalReviews.Data;
using PersonalReviews.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalReviews.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly ReviewContext _context;

        public IndexModel(ReviewContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get; set; } = new List<Review>();
        public SelectList CategoryOptions { get; set; }
        public string CategoryFilter { get; set; }
        public int? RatingFilter { get; set; }
        public string SortOrder { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public async Task OnGetAsync(string sortOrder, string categoryFilter, int? ratingFilter, int pageIndex = 1)
        {
            // Set the current sorting and filtering parameters
            SortOrder = sortOrder ?? "date_desc";
            CategoryFilter = categoryFilter;
            RatingFilter = ratingFilter;
            PageIndex = pageIndex;

            // Create a query for reviews
            var reviewsQuery = _context.Reviews.AsQueryable();

            // Apply category filter
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                reviewsQuery = reviewsQuery.Where(r => r.Category == CategoryFilter);
            }

            // Apply rating filter
            if (RatingFilter.HasValue)
            {
                reviewsQuery = reviewsQuery.Where(r => r.Rating == RatingFilter.Value);
            }

            // Apply sorting
            reviewsQuery = SortOrder switch
            {
                "title_asc" => reviewsQuery.OrderBy(r => r.Title),
                "title_desc" => reviewsQuery.OrderByDescending(r => r.Title),
                "rating_asc" => reviewsQuery.OrderBy(r => r.Rating),
                "rating_desc" => reviewsQuery.OrderByDescending(r => r.Rating),
                "date_asc" => reviewsQuery.OrderBy(r => r.DateReviewed),
                _ => reviewsQuery.OrderByDescending(r => r.DateReviewed) // default to date descending
            };

            // Define page size
            int pageSize = 5;

            // Calculate total number of pages
            TotalPages = (int)Math.Ceiling(await reviewsQuery.CountAsync() / (double)pageSize);

            // Fetch reviews for the current page
            Reviews = await reviewsQuery
                .Skip((PageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Populate category options for filtering
            CategoryOptions = new SelectList(await _context.Reviews
                .Select(r => r.Category)
                .Distinct()
                .ToListAsync());
        }
    }
}
