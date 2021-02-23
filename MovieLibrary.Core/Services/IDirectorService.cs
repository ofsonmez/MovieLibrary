using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Services
{
    public interface IDirectorService
    {
        // Our connection with Data and API.
        Task<IEnumerable<Director>> GetAllDirectors();
        Task<Director> GetDirectorById(int id);
        Task<Director> CreateDirector(Director newDirector);
        Task UpdateDirector(Director directorToBeUpdated, Director director);
        Task DeleteDirector(Director director);
    }
}