using Common.Api.DTOs.User;
using FluentValidation;
using Services.User.Api.Authentification;
using Services.User.Api.Domain.Models;
using Services.User.Api.Services;
using Services.User.Api.Services.Interface;

namespace Services.User.Api.Validator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        private readonly IProfilService _profilService;
        private readonly CurrentUserManager _currentUserManager;
        public UserUpdateValidator(IProfilService profilService, CurrentUserManager currentUserManager)
        {

            _profilService = profilService;
            _currentUserManager = currentUserManager;
            var userId = _currentUserManager.GetCurrentUser();
            

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Un nom d'utilisateur est requis.")
                .Matches("[A-Z]").WithMessage("Le nom d'utilisateur doit contenir au moins une lettre majuscule.")
                .Matches("[a-z]").WithMessage("Le nom d'utilisateur doit contenir au moins une minuscule.")
                //.Unless(x => x.UserName == user.UserName)
                .Must((UserName) =>
                {               
                    return _profilService.GetUserByUsername(UserName, userId).Result;
                }).WithMessage("Le nom d'utilisateur est déjà utilisée.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'adresse e-mail est requise.")
                .EmailAddress().WithMessage("L'adresse e-mail n'est pas valide.")
                //.Unless(x => x.UserName == user.UserName)
                .Must((email) =>
                {
                    return _profilService.GetUserByEmail(email, userId).Result;
                }).WithMessage("L'adresse e-mail est déjà utilisée.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Un prénom est requis.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Un nom est requis.");
        }


    }
}
