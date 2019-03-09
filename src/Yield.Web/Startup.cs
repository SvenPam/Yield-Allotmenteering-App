using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using VueCliMiddleware;
using Yield.Application.Allotment;
using Yield.Application.Bed;
using Yield.Application.Crop;
using Yield.Application.Plot;
using Yield.Core.Config;
using Yield.Core.Entities;
using Yield.Core.Entities.Interfaces;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            services.Configure<CosmosDbConfig>(Configuration.GetSection("CosmosDb"));

            services.AddTransient<IAllotmentService, AllotmentService>();
            services.AddTransient<IPlotService, PlotService>();
            services.AddTransient<IBedService, BedService>();
            services.AddTransient<ICropService, CropService>();

            var cosmosSettings = new CosmosDbConfig();
            Configuration.GetSection("CosmosDb").Bind(cosmosSettings);
            services.AddSingleton<IDocumentClient>(new DocumentClient(new Uri(cosmosSettings.Endpoint), cosmosSettings.Key));

            services.AddTransient<IRepository<IAllotment>, CosmosDbBaseRepository<IAllotment>>();
            services.AddTransient<IRepository<IPlot>, CosmosDbBaseRepository<IPlot>>();
            services.AddTransient<IRepository<IBed>, CosmosDbBaseRepository<IBed>>();
            services.AddTransient<IRepository<ICrop>, CosmosDbBaseRepository<ICrop>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Yield API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yield API");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id:guid?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve", port: 8080);
                }
            });
        }
    }
}
