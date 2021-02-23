using FluentValidation;
using MovieLibrary.API.DTO;

namespace MovieLibrary.API.Validators
{
    public class SaveDirectorResourceValidator : AbstractValidator<SaveDirectorDTO>
    {
        public SaveDirectorResourceValidator()
        {
            RuleFor(a => a.Name).NotEmpty().MaximumLength(50);
        }
    }
}