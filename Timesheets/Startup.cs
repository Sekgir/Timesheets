using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Repositories;
using Timesheets.DAL.Services;

namespace Timesheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void AddSqlRepositories(IServiceCollection services)
        {
            services.AddScoped<TimesheetsContext>();
            services.AddScoped<IContractsRepository, ContractsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IInvoicesRepository, InvoicesRepository>();
            services.AddScoped<IInvoiceTasksRepository, InvoiceTasksRepository>();
            services.AddScoped<IInvoiceTaskEmplsRepository, InvoiceTaskEmplsRepository>();
            services.AddScoped<IPersonsRepository, PersonsRepository>();
            services.AddScoped<ITaskEmployeesRepository, TaskEmployeesRepository>();
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<CustomersService>();
            services.AddScoped<ContractsService>();
            services.AddScoped<EmployeesService>();
            services.AddScoped<TasksService>();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSwagger(services);
            //services.AddSingleton<Data>();
            AddSqlRepositories(services);
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ������� Timesheets"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ������� Timesheets");
            });

        }
    }
}
