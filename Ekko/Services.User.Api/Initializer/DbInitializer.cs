using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Data;
using Services.User.Api.Initializer.Interface;

namespace Services.User.Api.Installers
{
    public class DbInitializer : IInitializer
    {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqloption => { });

            });
        }
    }
}
