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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Director>>> GetAllDirectors()
        {
            var directors = await _directorService.GetAllDirectors();

            var directorResult = _mapper.Map<IEnumerable<Director>, IEnumerable<DirectorDTO>>(directors);
            return Ok(directorResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetDirectorById(int id)
        {
            var director = await _directorService.GetDirectorById(id);

            var directorResource = _mapper.Map<Director, DirectorDTO>(director);
            return Ok(directorResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var director = await _directorService.GetDirectorById(id);

            if (director == null)
            {
                return NotFound();
            }

            await _directorService.DeleteDirector(director);

            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<DirectorDTO>> CreateArtist([FromBody] SaveDirectorDTO saveDirectorResource)
        {
            var validator = new SaveDirectorResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDirectorResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var directorToCreate = _mapper.Map<SaveDirectorDTO, Director>(saveDirectorResource);

            var newDirector = await _directorService.CreateDirector(directorToCreate);

            var director = await _directorService.GetDirectorById(newDirector.Id);

            var directorResource = _mapper.Map<Director, DirectorDTO>(director);

            return Ok(directorResource);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<DirectorDTO>> UpdateMovie(int id, [FromBody] SaveDirectorDTO saveDirectorResource)
        {
            var validator = new SaveDirectorResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveDirectorResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var directorToBeUpdated = await _directorService.GetDirectorById(id);

            if (directorToBeUpdated == null)
            {
                return NotFound();
            }

            var director = _mapper.Map<SaveDirectorDTO, Director>(saveDirectorResource);

            await _directorService.UpdateDirector(directorToBeUpdated, director);

            var updatedDirector = await _directorService.GetDirectorById(id);
            var updatedDirectorResource = _mapper.Map<Director, DirectorDTO>(updatedDirector);

            return Ok(updatedDirectorResource);
        }
    }
}