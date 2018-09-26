using System;
using System.IO;
using Elmah.Io.AspNetCore;
using LS.Infra.StoreContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using LS.Infra.StoreContext.Services;
using LS.Domain.StoreContext.Services;
using LS.Domain.StoreContext.Handlers;
using Microsoft.Extensions.Configuration;
using LS.Infra.StoreContext.Repositories;
using LS.Domain.StoreContext.Repositories;
using Microsoft.Extensions.DependencyInjection;
using LS.Shared;

namespace LS.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<LsDataContext, LsDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "LS Store", Version = "v1" });
            });

            services.AddElmahIo(c => {
                c.ApiKey = "36ab1733680942ad9c3ff7e02021666b";
                c.LogId = new Guid("aba64d40-95ac-4e78-8e06-48327619d5c6");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LS Store - V1");
            });

            app.UseElmahIo();
        }
    }
}
