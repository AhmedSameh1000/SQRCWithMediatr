using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveMangment.Persistence
{
    public static class PersistenceServicesRegisteration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRLeaveMangmentDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConStr"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveALLocationRepository, LeaveAllocationRepository>();
            return services;
        }
    }
}