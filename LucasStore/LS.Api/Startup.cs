using LS.Infra.StoreContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using LS.Infra.StoreContext.Services;
using LS.Domain.StoreContext.Services;
using LS.Infra.StoreContext.Repositories;
using LS.Domain.StoreContext.Repositories;
using Microsoft.Extensions.DependencyInjection;
using LS.Domain.StoreContext.Handlers;

namespace LS.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<LsDataContext, LsDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
