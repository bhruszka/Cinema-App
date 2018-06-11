using System;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Server;
using Server.Data;

namespace WebApp.Common {
    public static class ExtensionMethods {
        public static IWebHost EnsureDbIsCreated (this IWebHost webHost) {
            var serviceScopeFactory = (IServiceScopeFactory) webHost.Services.GetService (typeof (IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope ()) {
                var services = scope.ServiceProvider;
                try {
                    var dbContext = services.GetRequiredService<CinemaDbContext> ();
                    CinemaDbInitializer.Seed (dbContext);
                } catch (Exception ex) {
                    var logger = services.GetRequiredService<ILogger<Program>> ();
                    logger.LogError (ex, "An error occurred while seeding the database.");
                }
                //dbContext.Database.EnsureCreated ();
            }

            return webHost;
        }
    }
}