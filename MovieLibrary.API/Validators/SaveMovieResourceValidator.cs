using FluentValidation;
using MovieLibrary.API.DTO;

namespace MovieLibrary.API.Validators
{
    public class SaveMovieResourceValidator : AbstractValidator<SaveMovieDTO>
    {
        public SaveMovieResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.DirectorId)
                .NotEmpty()
                .WithMessage("'Director Id' must be different from 0");
        }
    }
}