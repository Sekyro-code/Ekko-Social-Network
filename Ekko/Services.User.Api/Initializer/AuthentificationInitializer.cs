
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Services.User.Api.Domain.Data;
using Services.User.Api.Initializer.Interface;
using System.Text;

namespace Services.User.Api.Initializer
{
    public class AuthentificationInitializer : IInitializer
    {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        configuration["Jwt:ServiceApiKey"] ?? throw new ArgumentNullException(
                            nameof(configuration),
                            "Jwt:ServiceApiKey est introuvable dans configuration"))),

                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "VotreCookie";
                options.LoginPath = "/Account/Login";
            });

            services.AddIdentity<Domain.Models.User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddHttpContextAccessor();

        }
    }
}
