using Business_Access_Layer.Services;
using Data_Access_Layer.Data;
using Data_Access_Layer.Interface;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
          

            var sqlConnectionString = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddScoped<IRepository<Person>, RepositoryPerson>();
            services.AddScoped<PersonService, PersonService>();
            services.AddScoped<IPostRepository, PostRepository>();


            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCore5WebApiService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCore5WebApiService v1");
                c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

//https://www.c-sharpcorner.com/article/create-restful-web-service-in-asp-net-core-5-web-api/

//https://www.roundthecode.com/dotnet/asp-net-core-web-api/four-useful-tips-using-asp-net-core-testserver-in-xunit

//https://www.roundthecode.com/dotnet/asp-net-core-web-api/asp-net-core-testserver-xunit-test-web-api-endpoints


//for unit test
//https://www.dotnetcurry.com/aspnet-core/1414/unit-testing-aspnet-core
//https://www.hosting.work/aspnet-core-moq-xunit-unit-testing/
//http://www.mukeshkumar.net/articles/testing/crud-operations-unit-testing-in-aspnet-core-web-api-with-xunit

//for code coverage
//https://www.code4it.dev/blog/code-coverage-vs-2019-coverlet