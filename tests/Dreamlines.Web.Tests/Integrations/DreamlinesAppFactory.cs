using System;
using Dreamlines.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dreamlines.Tests.Integrations {

    public class DreamlinesAppFactory<TStartup, TDbInitializer> : WebApplicationFactory<TStartup>
        where TStartup : class
        where TDbInitializer: IDreamlinesDbInitializer, new() {

        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(ConfigureServices);
        }

        protected virtual void ConfigureServices(IServiceCollection services) {
            // Create a new service provider.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Add a database context (DreamlinesContext) using an in-memory 
            // database for testing.
            services.AddDbContext<DreamlinesContext>(options => {
                options.UseInMemoryDatabase("InMemoryDreamlines");
                options.UseInternalServiceProvider(serviceProvider);
            });

            // Build the service provider.
            var sp = services.BuildServiceProvider();

            // Create a scope to obtain a reference to the database
            // context (DreamlinesContext).
            using (var scope = sp.CreateScope()) {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DreamlinesContext>();
                var logger = scopedServices
                    .GetRequiredService<ILogger<DreamlinesAppFactory<TStartup, TDbInitializer>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try {
                    // Seed the database with test data.
                    var initializer = new TDbInitializer();
                    initializer.Initialize(db);
                }
                catch (Exception ex) {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        $"database with test data. Error: {ex.Message}");
                }
            }
        }
        
    }

}