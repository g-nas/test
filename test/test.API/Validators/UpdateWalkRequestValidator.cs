using FluentValidation;
using test.API.Models.DTO;

namespace test.API.Validators
{
    public class UpdateWalkRequestValidator: AbstractValidator<UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
