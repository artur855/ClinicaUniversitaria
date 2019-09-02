using Hospital.Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;


namespace Hospital.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt => opt.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200",
                        "http://clinicauniversitaria-front.s3-website-us-east-1.amazonaws.com")
                    .AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContextService(Configuration);

            services.AddJwtTokenConfiguration(Configuration);

            services.AddJwtService();

            services.AddSwaggerConfiguration();

            services.AddAutoMapper();

            services.AddAuthenticationService();
            services.AddMedicServices();
            services.AddPatientService();
            services.AddUnitOfWorkService();
            services.AddUserService();
            services.AddExamRequestService();
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/ClinicaUniversitaria/swagger.json", "Clinica Universitaria API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}