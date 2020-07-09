using Kolokwium.DTO;
using Kolokwium.Mappers;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kolokwium
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
            services.AddScoped<IDbService, EfDbService>();
            services.AddScoped<IMapper<Musician, MusicianResponse>, MusicianToMusicianResponseMapper>();
            services.AddScoped<IMapper<MusicianRequest, Musician>, MusicianRequestToMusicianMapper>();
            services.AddDbContext<MusicDbContext>(options =>
            {
                options.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16944;Integrated Security=True");
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}