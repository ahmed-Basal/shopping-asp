using core.interfaces;
using core.Services;
using inftastructer.Data;
using inftastructer.Repository;
using inftastructer.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace inftastructer
{
    public  static class  InferastruterRegister
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenricRepo<>), typeof(GenericRepositories<>));

            //apply Unit OF Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IIamgeServices, Imagemangemt>();
            services.AddSingleton<IFileProvider>(
     new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            //apply DbContext
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            ;

            return services;
        }
    }
}
