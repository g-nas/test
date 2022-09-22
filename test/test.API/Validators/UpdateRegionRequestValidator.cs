using FluentValidation;
using test.API.Models.DTO;

namespace test.API.Validators
{
    public class UpdateRegionRequestValidator : AbstractValidator<UpdateRegionRequest>
    {
        public UpdateRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Lat).InclusiveBetween(-90, 90);
            RuleFor(x => x.Long).InclusiveBetween(-180, 180);
        }
    }
}
