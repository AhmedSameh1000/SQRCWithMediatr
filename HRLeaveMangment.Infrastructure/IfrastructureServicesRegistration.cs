using HRLeaveMangment.Application.Contracts.Infrastructure;
using HRLeaveMangment.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveMangment.Infrastructure
{
    public static class IfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}