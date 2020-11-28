using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Api.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Game.Api.Host
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private IWebHostEnvironment Environment { get; }
        readonly string MyAllowSpecificOrigins = "CorsPolicy";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.SetIsOriginAllowed(s => true)
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                  });
            });

            services.AddControllers();
            services.AddApiConfiguration(Environment, Configuration)
                .AddCustomDbContext(Configuration);
        }


        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseApiConfiguration();
        }
    }
}
