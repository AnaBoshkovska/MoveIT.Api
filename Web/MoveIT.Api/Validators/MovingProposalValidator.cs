using FluentValidation;

using MoveIT.Api.Dto;

namespace MoveIT.Api.Validators
{
    public class MovingProposalValidator : AbstractValidator<CreateMovingProposal>
    {
        public MovingProposalValidator()
        {
            RuleFor(x => x.AddressFrom).NotNull().NotEmpty();
            RuleFor(x => x.AddressTo).NotNull().NotEmpty();
            RuleFor(x => x.Distance).GreaterThan(0);
            RuleFor(x => x.LivingAreaSurface).GreaterThan(0);
        }
    }
}
