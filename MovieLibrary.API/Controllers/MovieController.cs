using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.API.DTO;
using MovieLibrary.API.Validators;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;

namespace MovieLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllWithDirector();
            
            var movieRescources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
            return Ok(movieRescources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            var movieResource = _mapper.Map<Movie, MovieDTO>(movie);
            return Ok(movieResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovie((movie));
            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<MovieDTO>> CreateMovie([FromBody] SaveMovieDTO saveMovieResource)
        {
            var validator = new SaveMovieResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveMovieResource);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var movieToCreate = _mapper.Map<SaveMovieDTO, Movie>(saveMovieResource);

            var newMovie = await _movieService.CreateMovie(movieToCreate);

            var movie = await _movieService.GetMovieById((newMovie.Id));

            var movieResource = _mapper.Map<Movie, MovieDTO>(movie);

            return Ok(movieResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDTO>> UpdateMovie(int id, [FromBody] SaveMovieDTO saveMovieResource)
        {
            var validator = new SaveMovieResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveMovieResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var movieToBeUpdated = await _movieService.GetMovieById(id);

            if (movieToBeUpdated == null)
            {
                return NotFound();
            }

            var movie = _mapper.Map<SaveMovieDTO, Movie>(saveMovieResource);

            await _movieService.UpdateMovie(movieToBeUpdated, movie);

            var updatedMovie = await _movieService.GetMovieById(id);
            var updatedMovieResource = _mapper.Map<Movie, MovieDTO>(updatedMovie);

            return Ok(updatedMovieResource);
        }
    }
}