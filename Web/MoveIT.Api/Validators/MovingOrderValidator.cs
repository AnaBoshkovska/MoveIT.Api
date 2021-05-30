using FluentValidation;

using MoveIT.Api.Dto;

namespace MoveIT.Api.Validators
{
    public class MovingOrderValidator : AbstractValidator<CreateOrder>
    {
        public MovingOrderValidator()
        {
            RuleFor(x => x.MovingProposalId).NotEmpty();
        }
    }
}
