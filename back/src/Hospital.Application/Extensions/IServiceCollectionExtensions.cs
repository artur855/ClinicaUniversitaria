using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Context;
using Hospital.Infra.Data.Repository;
using Hospital.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMedicServices(this IServiceCollection services)
        {
            services.AddScoped<IMedicService, MedicService>();
            services.AddScoped<IMedicRepository, MedicRepository>();
            return services;
        }

        public static IServiceCollection AddPatientService(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            return services;
        }

        public static IServiceCollection AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

        public static IServiceCollection AddJwtService(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgresqlString")));
            return services;
        }
    }
}
