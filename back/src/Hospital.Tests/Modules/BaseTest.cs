using Hospital.Application.Extensions;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Modules
{
    public class BaseTest
    {
        protected HospitalContext Context;
        private readonly ServiceCollection _services;
        private readonly ServiceProvider ServiceProvider;

        public BaseTest()
        {
            System.Console.WriteLine("oi");
            _services = new ServiceCollection();
            _services.AddDbContext<HospitalContext>(opt => opt.UseInMemoryDatabase("hospitalDb"));
            _services.AddMedicServices();
            _services.AddPatientServices();
            _services.AddUnitOfWorkService();

            ServiceProvider = _services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}