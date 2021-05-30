using FluentValidation;

using MoveIT.Api.Dto;

namespace MoveIT.Api.Validators
{
    public class UserRegisterValidator : AbstractValidator<RegisterUser>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty()
                .MinimumLength(6).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9 :])(?=.{6,})")
                .WithMessage("Password must contain an uppercase character, lowercase character, a digit,a non-alphanumeric character and must be at least six characters long.");
        }
    }
}
