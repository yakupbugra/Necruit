using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Necruit.Api.Configuration;
using Necruit.Application.IOC;
using Necruit.Application.Service;

namespace Necruit.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;//JsonNamingPolicy.CamelCase;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Necruit.Api", Version = "v1" });
            });

            services.AddLogging();
            services.AddInfrastructure(Configuration);
            services.AddServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Necruit.Api v1"));
            }
            else
            {
                app.UseExceptionHandler(config =>
                {
                    config.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            var ex = error.Error;
                            await context.Response.WriteAsync(new ServiceResult()
                            {
                                Success = false,
                                Message = ex.Message
                            }.ToString()); //ToString() is overridden to Serialize object
                        }
                    });
                });
            }

            app.UseMiddleware<CorrelationMiddleware>();
            //app.UseSerilogRequestLogging();

            app.UseMiddleware<LogRequestMiddleware>();
            app.UseMiddleware<LogResponseMiddleware>();
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