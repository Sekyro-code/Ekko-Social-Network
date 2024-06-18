using Common.Api.DTOs.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Services.User.Api.Initializer.Interface;
using Services.User.Api.Validator;
using System;
using System.Reflection;

namespace Services.User.Api.Initializer
{
    public class MvcInitializer : IInitializer
    {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddValidatorsFromAssembly(typeof(Program).Assembly);


            services.AddLogging();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User_API",
                    Description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
