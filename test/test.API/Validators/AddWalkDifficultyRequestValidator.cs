using FluentValidation;
using test.API.Models.DTO;

namespace test.API.Validators
{
    public class AddWalkDifficultyRequestValidator: AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
