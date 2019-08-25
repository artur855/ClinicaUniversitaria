using System.IO;
using Hospital.Application.Extensions;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Tests.Modules
{
    public class BaseTest
    {
        protected HospitalContext Context;
        private readonly ServiceCollection _services;
        private readonly ServiceProvider ServiceProvider;
        
        public BaseTest()
        {
            _services = new ServiceCollection();
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile(GetJsonPath());
            var configuration = builder.Build();

            _services.AddDbContext<HospitalContext>(opt => opt.UseInMemoryDatabase("hospitalDb"));

            _services.AddSingleton<IConfiguration>(provider => configuration);
            _services.AddJwtTokenConfiguration(configuration);
            
            _services.AddJwtTokenConfiguration(configuration);

            _services.AddJwtService();

            _services.AddSwaggerConfiguration();

            _services.AddAuthenticationService();
            _services.AddMedicServices();
            _services.AddPatientService();
            _services.AddUnitOfWorkService();
            _services.AddUserService();
            
            ServiceProvider = _services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
        
        public string GetJsonPath()
        {
            var dir = Directory.GetCurrentDirectory();
            var parent = Directory.GetParent(dir).Parent?.Parent;
            var path = parent.FullName + "/appsettings.json";
            return path;
        }
       
    }
}