using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PLekarska.Core;
using PLekarska.Infrastructure;
using PLekarska.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PLekarska.Infrastructure.Services;

namespace PrzychodniaLekarska
{
    public class Startup
    {
        public IWebHostEnvironment Env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddControllers();

            //Di
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            //Db
            services.AddDbContext<UserContext>(
               o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Przychodnia Lekarska", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "Gr2 UWM API V1"); });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
