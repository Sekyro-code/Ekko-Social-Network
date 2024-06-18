
using Common.Api.Auth;
using Common.Api.DTOs.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.User.Api.Authentification;
using Services.User.Api.Initializer.Interface;
using Services.User.Api.Repositories;
using Services.User.Api.Repositories.Interface;
using Services.User.Api.Services;
using Services.User.Api.Services.Interface;
using Services.User.Api.Validator;
using Services.User.Api.Validator.CustomIdentityError;
using System;

namespace Services.User.Api.Initializer
{
    public class ServicesApplicationInitializer : IInitializer
    {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProfilService, ProfilService>();
            services.AddScoped<IProfilRepository, ProfilRepository>();
            services.AddScoped<CurrentUserManager>();
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddSingleton(configuration);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
