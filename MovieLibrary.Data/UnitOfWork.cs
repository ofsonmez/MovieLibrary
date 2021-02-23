using System.Threading.Tasks;
using MovieLibrary.Core;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Data.Repositories;

namespace MovieLibrary.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieLibraryDbContext _context;
        private MovieRepository _movieRepository;
        private DirectorRepository _directorRepository;

        public UnitOfWork(MovieLibraryDbContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

        public IMovieRepository Movies => _movieRepository = _movieRepository ?? new MovieRepository(_context);

        public IDirectorRepository Directors =>
            _directorRepository = _directorRepository ?? new DirectorRepository(_context);
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}