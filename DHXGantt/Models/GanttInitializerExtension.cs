using DHXGantt.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHXGantt.Models
{
    public static class GanttInitializerExtension
    {
        public static IHost InitializeDatabase(this IHost webHost)
        {
            var serviceScopeFactory =
             (IServiceScopeFactory?)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory!.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                GanttSeeder.Seed(dbContext);
            }

            return webHost;
        }
    }
}
