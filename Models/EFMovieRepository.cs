using System;
using System.Linq;
namespace Assignment3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext context;
        public EFMovieRepository(MovieDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<MoviesResponse> Movies => context.Movies;
    }
}
