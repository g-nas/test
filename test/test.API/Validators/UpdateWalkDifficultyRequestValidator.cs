using FluentValidation;
using test.API.Models.DTO;

namespace test.API.Validators
{
    public class UpdateWalkDifficultyRequestValidator: AbstractValidator<UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
