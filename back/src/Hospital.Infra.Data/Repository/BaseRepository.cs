using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hospital.Infra.Data.Context;

namespace Hospital.Infra.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly HospitalContext _context;

        public BaseRepository(HospitalContext context)
        {
            _context = context;
        }

    }
}
