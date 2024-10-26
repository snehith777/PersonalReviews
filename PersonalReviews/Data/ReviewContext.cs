// Data/ReviewContext.cs
using Microsoft.EntityFrameworkCore;
using PersonalReviews.Models;

namespace PersonalReviews.Data
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }
}
