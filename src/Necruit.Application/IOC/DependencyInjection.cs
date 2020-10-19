using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Necruit.Application.Service.Jobs;
using Necruit.Application.Service.Talents;
using Necruit.Infrastructure.Persistence.Configurations;
using Necruit.Infrastructure.Persistence.Repository;
using System.Reflection;

namespace Necruit.Application.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NecruitDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NecruitConnection"), b => b.MigrationsAssembly(typeof(NecruitDbContext).Assembly.FullName))
            );

            services.AddScoped<DbContext>(provider => provider.GetService<NecruitDbContext>());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ITalentService, TalentService>();

            return services;
        }
    }
}