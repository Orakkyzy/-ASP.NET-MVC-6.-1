﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Infrastructure.InMemory;
using MyStore.Infrastructure.Interfaces;

namespace MyStore
{
    public class Startup
    {
        /// <summary>
        /// Добавляем свойство для доступа к конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Добавляем новый конструктор, принимающий интерфейс IConfiguration
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем сервисы, необходимые для mvc
            services.AddMvc();
            // Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Добавляем расширение для использования статических файлов, т.к. appsettings.json -
           // это статический файл
app.UseStaticFiles();
            //Добавляем обработку запросов в mvc-формате
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Employees}/{action=Index}/{id?}");
            });




            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //Добавляем расширение для использования статических файлов, т.к. appsettings.json -
            // это статический файл
            //app.UseStaticFiles();
            //var hello = Configuration["CustomHelloWorld"];
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(hello);
            //});
        }
    }
}
