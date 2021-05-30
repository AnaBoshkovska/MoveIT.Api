using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MoveIT.Data;
using MoveIT.Api.Extensions;
using MoveIT.Core.Models;
using MoveIT.Services.Authentication;

namespace MoveIT.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuth(jwtSettings);

           
            services.AddDbContext<MoveItDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentityCore<User>().AddEntityFrameworkStores<MoveItDbContext>().AddDefaultTokenProviders();
            
            Extensions.Services.Configure(services);
            
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";
                options.DefaultModelsExpandDepth(-1);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Move It V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();
            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
