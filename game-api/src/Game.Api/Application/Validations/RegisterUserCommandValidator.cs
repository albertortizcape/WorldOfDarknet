using FluentValidation;
using Game.Api.Application.Commands.Account;
using Game.Domain.Entities.UserAggregate;

namespace Game.Api.Application.Validations
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Incorrect email address")
                .MustAsync(async (email, cancellation) => {
                    bool exists = await userRepository.CheckEmailExistAsync(email);
                    return !exists;
                }).WithMessage("Email must be unique");

            RuleFor(c => c.Password)
                .MinimumLength(6)
                .NotEmpty()
                .NotNull()
                .WithMessage("Incorrect email address");
        }
    }
}
