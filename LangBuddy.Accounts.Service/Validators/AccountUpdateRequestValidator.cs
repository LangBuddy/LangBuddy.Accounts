using FluentValidation;
using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Validators
{
    public class AccountUpdateRequestValidator : AbstractValidator<AccountUpdateRequest>
    {
        public AccountUpdateRequestValidator()
        {
            RuleFor(el => el).NotNull().NotEmpty();
            RuleFor(el => el.Email).EmailAddress();
        }
    }
}
