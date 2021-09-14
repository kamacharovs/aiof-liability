using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace kamafi.liability.core
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public readonly IConfiguration _config;
        public readonly IWebHostEnvironment _env;

        public Startup(
            IConfiguration config,
            IWebHostEnvironment env)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "kamafi.liability.core", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "aiof.liability.core v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
