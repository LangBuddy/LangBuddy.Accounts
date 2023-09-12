using FluentValidation;
using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Validators
{
    public class AccountCreateRequestValidator: AbstractValidator<AccountCreateRequest>
    {
        public AccountCreateRequestValidator() 
        {
            RuleFor(el => el).NotNull().NotEmpty();
            RuleFor(el => el.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(el => el.Nickname).NotNull().NotEmpty();
            RuleFor(el => el.PasswordHash).NotNull().NotEmpty();
            RuleFor(el => el.PasswordSalt).NotNull().NotEmpty();
        }
    }
}
