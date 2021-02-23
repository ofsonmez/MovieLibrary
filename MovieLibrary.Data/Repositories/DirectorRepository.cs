using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Repositories;

namespace MovieLibrary.Data.Repositories
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieLibraryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Director>> GetAllWithMovieAsync()
        {
            return await MovieLibraryDbContext.Directors.Include(a => a.Movies)
                .ToListAsync();
        }

        public Task<Director> GetWithMovieByIdAsync(int id)
        {
            return MovieLibraryDbContext.Directors.Include(a => a.Movies)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private MovieLibraryDbContext MovieLibraryDbContext
        {
            get
            {
                return Context as MovieLibraryDbContext;
            }
        }
    }
}