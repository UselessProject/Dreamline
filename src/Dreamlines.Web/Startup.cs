using Dreamlines.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
// using FluentMigrator.Runner;

namespace Dreamlines.Web {

    public class Startup {

        public static readonly string ConnectionStringName = "DreamlinesContext";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDbContext(DbContextOptionsBuilder options) {
            options.UseMySql(Configuration.GetConnectionString(ConnectionStringName))
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // registering the database context into the service container
            services.AddDbContext<DreamlinesContext>(ConfigureDbContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }

    }

}
