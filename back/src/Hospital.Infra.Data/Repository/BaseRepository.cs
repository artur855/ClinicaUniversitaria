using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
