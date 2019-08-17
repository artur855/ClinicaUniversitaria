using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests.Modules
{
    public class BaseTest
    {
        protected HospitalContext Context;

        public BaseTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<HospitalContext>().UseInMemoryDatabase("hospitaldb");
            Context = new HospitalContext(dbContextOptions.Options);
        }

    }
}