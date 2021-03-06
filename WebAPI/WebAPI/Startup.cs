using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using WebAPI.Models.Doctor;
using WebAPI.Models.PatientProfile;
using WebAPI.Repositories;
using WebAPI.Repositories.Doctor;
using WebAPI.Repositories.PatientProfile;
using WebAPI.Services;
using WebAPI.Services.Doctor;
using WebAPI.Services.PatientProfile;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //DB
            services.AddDbContext<AuthenticationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<MedicalVisitContext>(o => 
            o.UseSqlServer(Configuration.GetConnectionString("MedicalVisitConnection")));

            services.AddDbContext<DoctorContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("DoctorConnection")));

            services.AddDbContext<MedicamentContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("MedicamentConnection")));

            services.AddDbContext<DiseaseContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("DiseaseConnection")));

            services.AddDbContext<PatientContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("PatientProfileConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationContext>(); 

            //Di
            services.AddScoped(typeof(IMedicalVisitService), typeof(MedicalVisitService));
            services.AddScoped(typeof(IMedicalVisitRepository), typeof(MedicalVisitRepository));

            services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
            services.AddScoped(typeof(IDoctorRepository), typeof(DoctorRepository));

            services.AddScoped(typeof(IMedicamentService), typeof(MedicamentService));
            services.AddScoped(typeof(IMedicamentRepository), typeof(MedicamentRepository));

            services.AddScoped(typeof(IDiseaseService), typeof(DiseaseService));
            services.AddScoped(typeof(IDiseaseRepository), typeof(DiseaseRepository));

            services.AddScoped(typeof(IPatientService), typeof(PatientService));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));


            //Security
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });

            //Jwt Authentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigin");
            app.UseCors(builder =>
            builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyHeader()
            .AllowAnyMethod()
            );


            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
