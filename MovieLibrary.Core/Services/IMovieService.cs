using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Services
{
    public interface IMovieService
    {
        // Our connection with Data and API.
        Task<IEnumerable<Movie>> GetAllWithDirector();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetMovieByDirectorId(int directorId);
        Task<Movie> CreateMovie(Movie newMovie);
        Task UpdateMovie(Movie movieToBeUpdated, Movie movie);
        Task DeleteMovie(Movie movie);
    }
}