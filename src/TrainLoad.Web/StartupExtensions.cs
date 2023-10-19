using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Hosting;
using StruCal.TrainLoad.App;
using Quartz.Spi;
using Quartz.Simpl;
using Quartz;
using StruCal.TrainLoad.App.Storage;
using StruCal.TrainLoad.Domain.GradientColor;
using StruCal.TrainLoad.Domain;

namespace StruCal.TrainLoad
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder AddTrainLoadStaticFiles(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) return builder;

            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, Startup.ClientName)),
                RequestPath = $"/{Startup.ClientName}"
            });
            return builder;
        }

        public static IApplicationBuilder AddTrainLoad(this IApplicationBuilder builder)
        {
            return builder;
        }

        public static IServiceCollection AddTrainLoad(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<TrainLoadService>();
            services.AddSingleton<IResultStorage, MemoryDataProvider>();
            services.AddScoped<IGradient, LinearGradient>();
            services.AddScoped<IColorCalculatorFactory, ColorCalculatorFactory>();
            services.AddScoped<ITrainLoadResultCreator, TrainLoadResultCreator>();
            services.AddScoped<ITrainLoadCalculator, TrainLoadCalculator>();
            services.AddScoped<ITrainLoadService, TrainLoadService>();
            services.AddTransient<IFEMCalculatorFacade, FEMCalculatorFacade>();

            services.AddSingleton<ITypeLoadHelper, SimpleTypeLoadHelper>();

            services.AddQuartz(cfg =>
            {
                cfg.UseMicrosoftDependencyInjectionJobFactory();
            });

            return services;
        }
    }
}