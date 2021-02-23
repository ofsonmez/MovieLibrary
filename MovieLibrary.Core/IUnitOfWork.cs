using System;
using System.Threading.Tasks;
using MovieLibrary.Core.Repositories;

namespace MovieLibrary.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IDirectorRepository Directors { get; }
        Task<int> CommitAsync();
    }
}