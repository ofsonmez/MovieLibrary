using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;

namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Movie>> GetAllWithDirector()
        {
            return await _unitOfWork.Movies.GetAllWithDirectorAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _unitOfWork.Movies.GetWithDirectorByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMovieByDirectorId(int directorId)
        {
            return await _unitOfWork.Movies.GetAllWithDirectorByDirectorIdAsync(directorId);
        }

        public async Task<Movie> CreateMovie(Movie newMovie)
        {
            await _unitOfWork.Movies.AddAsync(newMovie);
            await _unitOfWork.CommitAsync();
            return newMovie;
        }

        public async Task UpdateMovie(Movie movieToBeUpdated, Movie movie)
        {
            movieToBeUpdated.Name = movie.Name;
            movieToBeUpdated.DirectorId = movie.DirectorId;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _unitOfWork.Movies.Remove(movie);
            await _unitOfWork.CommitAsync();
        }
    }
}