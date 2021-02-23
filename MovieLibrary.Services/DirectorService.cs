using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Core;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;

namespace MovieLibrary.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _unitOfWork.Directors.GetAllAsync();
        }

        public async Task<Director> GetDirectorById(int id)
        {
            return await _unitOfWork.Directors.GetWithMovieByIdAsync(id);
        }

        public async Task<Director> CreateDirector(Director newDirector)
        {
            await _unitOfWork.Directors.AddAsync(newDirector);
            return newDirector;
        }

        public async Task UpdateDirector(Director directorToBeUpdated, Director director)
        {
            directorToBeUpdated.Name = director.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteDirector(Director director)
        {
            _unitOfWork.Directors.Remove(director);

            await _unitOfWork.CommitAsync();
        }
    }
}