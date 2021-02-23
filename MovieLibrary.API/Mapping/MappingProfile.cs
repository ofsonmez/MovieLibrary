using AutoMapper;
using MovieLibrary.API.DTO;
using MovieLibrary.Core.Models;

namespace MovieLibrary.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Movie, MovieDTO>();
            CreateMap<Director, DirectorDTO>();
            
            // Resource To Domain
            CreateMap<MovieDTO, Movie>();
            CreateMap<DirectorDTO, Director>();
            
            // Just Use Necessary Entities
            CreateMap<SaveMovieDTO, Movie>();
            CreateMap<SaveDirectorDTO, Director>();
        }
    }
}