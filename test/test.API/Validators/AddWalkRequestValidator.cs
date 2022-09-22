using FluentValidation;
using test.API.Models.DTO;

namespace test.API.Validators
{
    public class AddWalkRequestValidator: AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
