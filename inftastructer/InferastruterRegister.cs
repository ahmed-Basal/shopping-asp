using core.interfaces;
using inftastructer.Data;
using inftastructer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace inftastructer
{
    public  static class  InferastruterRegister
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenricRepo<>), typeof(GenericRepositories<>));

            //apply Unit OF Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //apply DbContext
            services.AddDbContext<AppDbcontext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            ;

            return services;
        }
    }
}
