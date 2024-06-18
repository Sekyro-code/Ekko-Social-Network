using Common.Api.DTOs.User;
using FluentValidation;
using Services.User.Api.Services;
using Services.User.Api.Services.Interface;

namespace Services.User.Api.Validator
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly IAccountService _accountService;
        public UserRegisterValidator(IAccountService accountService)
        {

            _accountService = accountService;

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Un nom d'utilisateur est requis.")
                .Matches("[A-Z]").WithMessage("Le nom d'utilisateur doit contenir au moins une lettre majuscule.")
                .Matches("[a-z]").WithMessage("Le nom d'utilisateur doit contenir au moins une minuscule.")
                .Must((UserName) =>
                {
                    return !_accountService.GetUserByUsername(UserName).Result;
                }).WithMessage("Le nom d'utilisateur est déjà utilisée.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'adresse e-mail est requise.")
                .EmailAddress().WithMessage("L'adresse e-mail n'est pas valide.")
                .Must((email) =>
                {
                    return !_accountService.GetUserByEmail(email).Result;
                }).WithMessage("L'adresse e-mail est déjà utilisée.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Le mot de passe est requis.")
                .Length(8, 12).WithMessage("Le mot de passe doit comporter entre 8 et 12 caractères.")
                .Matches("[A-Z]").WithMessage("Le mot de passe doit contenir au moins une lettre majuscule ou majuscule.")
                .Matches("[a-z]").WithMessage("Le mot de passe doit contenir au moins une minuscule.")
                .Matches("[0-9]").WithMessage("Le mot de passe doit contenir au moins un chiffre.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Le champ Confirmer le mot de passe est obligatoire.")
                .Equal(x => x.Password)
                .WithMessage("Les mots de passe ne correspondent pas.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Un prénom est requis.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Un nom est requis.");
        }


    }
}
