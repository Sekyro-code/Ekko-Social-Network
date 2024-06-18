using Common.Api.DTOs.User;
using FluentValidation;
using Services.User.Api.Services.Interface;

namespace Services.User.Api.Validator
{
    public class UserAuthentificationValidator : AbstractValidator<UserLoginDto>
    {
        private readonly IAccountService _userAccount;
        public UserAuthentificationValidator(IAccountService userAccount)
        {

            _userAccount = userAccount;


            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Le Format de l'email n'est pas correct.")
                .NotEmpty()
                .WithMessage("La Connexion nécessite une adresse mail.")
                .Must((email) =>
                {
                    return _userAccount.GetUserByEmail(email).Result;
                }).WithMessage((email) => $"L'utilisateur n'est enregistré avec cette adresse mail : '{email.Email}'.");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Le mot de passe est requis.");

        }
    }
}
