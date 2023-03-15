using PlateformService.Data;
using PlateformService.Models;
using Microsoft.EntityFrameworkCore;
using PlateformService.SyncDataServices.Http;

namespace PlateformService.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAppContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:PlateformConnection"];
            //services.AddDbContext<AppDbContext>(options =>
            //                                    options.UseSqlServer(connectionString));
            services.AddDbContext<AppDbContext>(options =>
                                                options.UseInMemoryDatabase("PlateformService"));
        }

        public static void ConfigureDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPlateformRepo, PlateformRepo>();
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
        }

        public static void SeedData(this IServiceCollection services, IApplicationBuilder app)
        {
            using (IServiceScope? serviceScope = app.ApplicationServices.CreateScope())
            {
                PrepData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void PrepData(AppDbContext _dbContext)
        {
            if (!_dbContext.Set<Plateform>().Any())
            {
                _dbContext.Plateforms.AddRange(
                    new Plateform() { Name = ".Net", Publisher = "Microsoft", Cost = "Free" },
                    new Plateform() { Name = "Docker", Publisher = "Microsoft", Cost = "Free" },
                    new Plateform() { Name = "Azure", Publisher = "Microsoft", Cost = "Free" }
                    );
                _dbContext.SaveChanges();
            }
        }
    }
}
