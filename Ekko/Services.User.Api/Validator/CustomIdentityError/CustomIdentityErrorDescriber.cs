using Microsoft.AspNetCore.Identity;

namespace Services.User.Api.Validator.CustomIdentityError
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = nameof(DuplicateEmail), Description = $"L'adresse e-mail '{email}' est déjà utilisée." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Le nom d'utilisateur '{userName}' est déjà utilisé" };
        }

        public override IdentityError InvalidEmail(string? email)
        {
            return new IdentityError { Code = nameof(InvalidEmail), Description = $"Le nom d'utilisateur '{email}' est déjà utilisé" };
        }

    }
}