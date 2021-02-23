using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Repositories;

namespace MovieLibrary.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieLibraryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> GetAllWithDirectorAsync()
        {
            return await MovieLibraryDbContext.Movies
                .Include(m => m.Director)
                .ToListAsync();
        }

        public async Task<Movie> GetWithDirectorByIdAsync(int id)
        {
            return await MovieLibraryDbContext.Movies
                .Include(m => m.Director)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllWithDirectorByDirectorIdAsync(int directorId)
        {
            return await MovieLibraryDbContext.Movies
                .Include(m => m.Director)
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();
        }

        private MovieLibraryDbContext MovieLibraryDbContext
        {
            get { return Context as MovieLibraryDbContext; }
        }
    }
}