using Dreamlines.Data;
using Dreamlines.Dtos;
using Dreamlines.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Dreamlines.Web {

    public class Startup {

        public static readonly string ConnectionStringName = "DreamlinesContext";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDbContext(DbContextOptionsBuilder options) {
            options
                .UseMySql(
                    Configuration.GetConnectionString(ConnectionStringName),
                    builder => builder.MigrationsAssembly("Dreamlines.Web")
                )
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            // registering the database context into the service container
            services.AddDbContext<DreamlinesContext>(ConfigureDbContext);

            // initializing the query processor            
            services
                .AddScoped<IQueryProcessor, DefaultQueryProcessor>()
                .AddQuery<SalesUnitQuery, PaginatedResult<SalesUnitSummary>, SalesUnitQueryHandler>()
                .AddQuery<BookingQuery, PaginatedResult<BookingSummary>, BookingQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

    }

}