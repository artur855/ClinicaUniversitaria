using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Hospital.Infra.Data.Mapping;

namespace Hospital.Infra.Data.Context
{
    public class HospitalContext : DbContext
    {
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MedicEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEntityConfiguration());
        }
    }
}
