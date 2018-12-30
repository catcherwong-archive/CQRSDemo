namespace CQRSBasicDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CQRSBasicDemo.Domains.Entities;
    using CQRSBasicDemo.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CqrsContext>(options =>
               options.UseSqlite(
                   Configuration.GetConnectionString("WriteConn")
               )
           );

            var typeList = new List<Type>
            {
                typeof(IDispatcher),
            };

            // Use Scrutor to register services
            services.Scan(s => s
                .FromAssembliesOf(typeList)
                .AddClasses()
                .AsImplementedInterfaces());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CqrsContext cqrsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            cqrsContext.Database.EnsureCreated();
        }
    }
}
