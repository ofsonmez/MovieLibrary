using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllWithDirectorAsync();
        Task<Movie> GetWithDirectorByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllWithDirectorByDirectorIdAsync(int directorId);
    }
}