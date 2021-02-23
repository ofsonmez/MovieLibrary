using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Repositories
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Task<IEnumerable<Director>> GetAllWithMovieAsync();
        Task<Director> GetWithMovieByIdAsync(int id);
    }
}